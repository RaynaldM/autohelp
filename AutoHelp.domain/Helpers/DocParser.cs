using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using AutoHelp.domain.Models;
using Jolt;
using Assembly = System.Reflection.Assembly;
using Exception = System.Exception;

namespace AutoHelp.domain.Helpers
{
    public class DocParser
    {
        XmlDocCommentReader _reader;

        public Models.Assembly Parse(string assemblyFile, Boolean bParseNamespace = true)
        {
            try
            {
                var namespaces = new List<Namespace>();
                byte[] b = File.ReadAllBytes(assemblyFile);
                var assembly = Assembly.Load(b);
                //var assembly = Assembly.LoadFile(assemblyFile);
                if (bParseNamespace)
                {

                    _reader = new XmlDocCommentReader(assemblyFile.Replace(".dll", ".xml"));
                    FindTypes(assembly, namespaces);

                    namespaces = namespaces.OrderBy(o => o.Name).ToList();

                    foreach (var nameSpace in namespaces)
                    {
                        nameSpace.Classes = nameSpace.Classes.OrderBy(c => c.Name).ToList();
                    }
                    
                }

                var a = new Models.Assembly
                {
                    Id = assembly.ManifestModule.ModuleVersionId,
                    Name = assembly.GetName().Name,
                    FullName = assembly.FullName,
                    Namespaces = namespaces
                };
                return a;
            }
            catch (Exception ex)
            {
                Trace.TraceError("DLL {0} : Parse Problem. {1} => {2}", assemblyFile, ex.Message, ex.Source);
                return null;
            }
        }

        private void FindTypes(Assembly assembly, List<Namespace> namespaces)
        {
            Type[] typesInAsm = assembly.GetLoadableTypes().Where(p => p.IsPublic || p.IsNestedPublic || p.IsVisible).ToArray();
            foreach (var type in typesInAsm)
            {
                try
                {
                    // The namespace is everything before this type name, e.g. [Docy.Core].XYZ
                    string typeNamespace = type.Namespace;

                    var nameSpace = namespaces.FirstOrDefault(n => n.Name == typeNamespace);
                    if (nameSpace == null)
                    {
                        nameSpace = new Namespace { Name = typeNamespace };
                        namespaces.Add(nameSpace);
                    }

                    // Comments
                    var element = _reader.GetComments(type);
                    var comments = GetCommonTags(element);

                    var typeBase = new TypeBase
                    {
                        Namespace = nameSpace,
                        IsAbstract = type.IsAbstract,
                        IsPrimitive = type.IsPrimitive,
                        IsPublic = type.IsPublic,
                        IsSealed = type.IsSealed,
                        IsNested = type.IsNested,
                        ParentClass = type.BaseType != null ? type.BaseType.FullName : "",
                        Parents = GetParents(type),
                        Name = GetTypeName(type),
                        Fullname = GetFullTypeName(type),
                        Example = comments.Example,
                        Remarks = comments.Remarks,
                        Returns = comments.Returns,
                        Summary = comments.Summary
                    };

                    typeBase.Constructors = GetConstructors(type, typeBase);
                    typeBase.Methods = GetMethods(type, typeBase);
                    typeBase.Properties = GetProperties(type, typeBase);

                    if (type.IsClass)
                    {
                        if (type.BaseType != null && type.BaseType == typeof(Delegate) || type.BaseType == typeof(MulticastDelegate))
                        {
                            typeBase.ObjectType = "Delegate";
                            nameSpace.Delegates.Add(typeBase);
                        }
                        else
                        {
                            typeBase.ObjectType = "Class";
                            nameSpace.Classes.Add(typeBase);
                        }
                    }
                    else if (type.IsEnum)
                    {
                        typeBase.ObjectType = "Enumeration";
                        typeBase.Members = GetMembers(type);
                        nameSpace.Enumerations.Add(typeBase);
                    }
                    else if (type.IsValueType)
                    {
                        typeBase.ObjectType = "Structure";
                        nameSpace.Structures.Add(typeBase);
                    }
                    else if (type.IsInterface)
                    {
                        typeBase.ObjectType = "Interface";
                        nameSpace.Interfaces.Add(typeBase);
                    }
                    else
                    {
                        typeBase.ObjectType = "Delegate";
                        // TODO: Find out how to get delegate types
                        nameSpace.Delegates.Add(typeBase);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Type {0} : Parse Problem. {1} => {2}", type, ex.Message, ex.Source);
                }
            }
        }

        private List<TypeSummary> GetParents(Type type)
        {
            var list = new List<TypeSummary>();

            var current = type;

            while (current.BaseType != null)
            {
                var summary = new TypeSummary { Name = current.BaseType.Name, Fullname = GetFullTypeName(current.BaseType) };

                list.Add(summary);
                current = current.BaseType;
            }

            list.Reverse();
            return list;
        }

        private IList<Constructor> GetConstructors(Type type, TypeBase parent)
        {
            var list = new List<Constructor>();

            foreach (var info in type.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                try
                {

                    var constructor = new Constructor
                    {
                        Parent = parent,
                        Name = parent.Name,
                        ParentClass = parent.Id,
                        UseHashCodeForId = true,
                        Attributes = info.Attributes.ToString(),
                    };

                    // Parameters
                    if (info.IsGenericMethod)
                    {
                        var arguments = info.GetGenericArguments().Select(genericType => genericType.Name).ToList();
                        constructor.Name = info.Name + "<" + string.Join(",", arguments) + ">";
                    }

                    try
                    {
                        constructor.Fullname = info.ToString();

                        // Get common tags
                        var element = _reader.GetComments(info);
                        var comments = GetCommonTags(element);
                        constructor.Example = comments.Example;
                        constructor.Remarks = comments.Remarks;
                        constructor.Returns = comments.Returns;
                        constructor.Summary = comments.Summary;
                        constructor.Parameters = GetMethodParameters(info.GetParameters(), element);
                    }
                    catch (Exception ex)
                    {
                        constructor.LoadError = true;
                        constructor.Fullname = ex.Message;
                    }

                    list.Add(constructor);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("constructor {0} : Parse Problem. {1} => {2}", info.Name, ex.Message, ex.Source);
                }
            }

            list = list.OrderBy(m => m.Name).ToList();
            return list;
        }

        private IList<Method> GetMethods(Type type, TypeBase parent)
        {
            var list = new List<Method>();

            // Used for ID generation
            var methodNames = new List<string>();

            // Get only methods for this object, none of the inherited methods.
            foreach (var info in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                try
                {
                    if (!info.IsSpecialName)
                    {
                        var method = new Method
                     {
                         Parent = parent,
                         ParentClass = parent.Id,
                         Name = info.Name,
                     };

                        // Contains overloads - ID is the hashcode
                        if (methodNames.Contains(info.Name))
                            method.UseHashCodeForId = true;

                        methodNames.Add(info.Name);

                        if (info.IsGenericMethod)
                        {
                            var arguments = info.GetGenericArguments().Select(genericType => genericType.Name).ToList();

                            method.Name = info.Name + "<" + string.Join(",", arguments) + ">";
                            method.UseHashCodeForId = true;
                        }

                        try
                        {
                            method.Fullname = info.ToString();
                            method.ReturnType = GetTypeName(info.ReturnType);
                            method.ReturnTypeFullName = GetFullTypeName(info.ReturnType);

                            // Get common tags
                            var element =
                                _reader.GetComments(info.IsGenericMethod ? info.GetGenericMethodDefinition() : info);
                            var comments = GetCommonTags(element);
                            method.Example = comments.Example;
                            method.Remarks = comments.Remarks;
                            method.Returns = comments.Returns;
                            method.Summary = comments.Summary;
                            method.Parameters = GetMethodParameters(info.GetParameters(), element); // Parameters


                        }
                        catch (Exception ex)
                        {
                            method.LoadError = true;
                            method.Fullname = ex.Message;
                        }

                        list.Add(method);

                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Type {0} : Parse methods Problem. {1} => {2}", type, ex.Message, ex.Source);
                }
            }

            list = list.OrderBy(m => m.Name).ToList();
            return list;
        }

        private IList<Parameter> GetMethodParameters(IEnumerable<ParameterInfo> parameters, XElement element)
        {
            IEnumerable<XElement> paramElements = new List<XElement>();

            if (element != null)
                paramElements = element.Elements().Where(e => e.Name.LocalName == "param");

            var list = new List<Parameter>();
            foreach (var info in parameters)
            {
                var parameter = new Parameter
                {
                    Name = info.Name,
                    IsOut = info.IsOut,
                    IsRet = info.IsRetval,
                    Type = GetTypeName(info.ParameterType),
                    TypeFullName = GetFullTypeName(info.ParameterType)
                };

                var current = paramElements.FirstOrDefault(e => e.Attribute("name") != null && e.Attribute("name").Value == parameter.Name);
                if (current != null)
                {
                    // TODO: get attributes
                    parameter.Description = current.Value;

                    if (!string.IsNullOrEmpty(parameter.Description))
                        parameter.Description = parameter.Description.Trim();
                }

                list.Add(parameter);
            }

            return list;
        }

        private IList<Property> GetProperties(Type type, TypeBase parent)
        {
            var list = new List<Property>();

            // Get both public and protected properties, and no inherited ones unless overridden
            foreach (var info in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                try
                {

                    var property = new Property
                    {
                        Name = info.Name,
                        Parent = parent,
                        ParentClass = parent.Id,
                        Attributes = info.Attributes.ToString(),
                    };

                    try
                    {

                        property.Fullname = info.ToString();

                        property.Type = GetTypeName(info.PropertyType);
                        property.TypeFullName = GetFullTypeName(info.PropertyType);

                        var element = _reader.GetComments(info);
                        var comments = GetCommonTags(element);
                        property.Example = comments.Example;
                        property.Remarks = comments.Remarks;
                        property.Returns = comments.Returns;
                        property.Summary = comments.Summary;
                    }
                    catch (Exception ex)
                    {
                        property.LoadError = true;
                        property.Fullname = ex.Message;
                    }
                    list.Add(property);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Type {0} : Parse Property Problem. {1} => {2}", info.Name, ex.Message, ex.Source);
                }
            }

            list = list.OrderBy(m => m.Name).ToList();
            return list;
        }

        private IList<MemberSummary> GetMembers(Type type)
        {
            // For enumerations
            var list = new List<MemberSummary>();

            foreach (var info in type.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                if (info.Name != "value__")
                {
                    var element = _reader.GetComments(info);
                    var comments = GetCommonTags(element);

                    var summary = new MemberSummary
                    {
                        Name = info.Name,
                        Description = comments.Summary
                    };

                    list.Add(summary);
                }
            }

            list = list.OrderBy(m => m.Name).ToList();
            return list;
        }

        private CommentsBase GetCommonTags(XElement element)
        {
            var comments = new CommentsBase();

            if (element != null)
            {
                // Example
                var current = element.Elements().FirstOrDefault(e => e.Name.LocalName == "example");
                if (current != null)
                    comments.Example = current.Value;

                // Remarks
                current = element.Elements().FirstOrDefault(e => e.Name.LocalName == "remarks");
                if (current != null)
                    comments.Remarks = current.Value;

                // Returns
                current = element.Elements().FirstOrDefault(e => e.Name.LocalName == "returns");
                if (current != null)
                    comments.Returns = current.Value;

                // Summary
                current = element.Elements().FirstOrDefault(e => e.Name.LocalName == "summary");
                if (current != null)
                    comments.Summary = current.Value;

                comments.Example = comments.Example.Trim();
                comments.Remarks = comments.Remarks.Trim();
                comments.Returns = comments.Returns.Trim();
                comments.Summary = comments.Summary.Trim();
            }

            return comments;
        }

        /// <summary>
        /// Get the type name with a sprinkle of magic dust if it's a generic type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTypeName(Type type)
        {
            var result = type.Name;

            if (type.IsGenericParameter || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                result = GetFriendlyGenericName(type);
            }

            return result;
        }

        private string GetFullTypeName(Type type)
        {
            var result = type.FullName;
            if (string.IsNullOrEmpty(result))
                result = type.Name;

            if (type.IsGenericParameter || (type.IsGenericType))
            {
                result = GetFriendlyGenericName(type);
            }

            return result;
        }

        private string GetFriendlyGenericName(Type paramType)
        {
            string result;

            if (paramType.IsGenericType || paramType.IsGenericParameter)
            {
                // Turn #1 into #3
                // #1 System.Linq.Expressions.Expression`1[[System.Func`2[[Roadkill.Core.User, Roadkill.Core, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null],[System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
                // #2 System.Linq.Expressions.Expression`1[[System.Func`2[[Roadkill.Core.User],[System.Object]]]]
                // #3 System.Linq.Expressions.Expression<Func<User,object>>

                var csharpProvider = CodeDomProvider.CreateProvider("C#");
                var typeReference = new CodeTypeReference(paramType);
                var variableDeclaration = new CodeVariableDeclarationStatement(typeReference, "dummy");
                var stringBuilder = new StringBuilder();
                using (var writer = new StringWriter(stringBuilder))
                {
                    csharpProvider.GenerateCodeFromStatement(variableDeclaration, writer, new CodeGeneratorOptions());
                }

                stringBuilder.Replace(" dummy;", null);
                result = stringBuilder.ToString();
            }
            else
            {
                result = paramType.Name;
            }

            return result.Replace("\r", "").Replace("\n", "");
        }
    }
}
