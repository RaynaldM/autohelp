using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Jolt Library")]
[assembly: AssemblyDescription("Contains commonly used classes and core library functionality.")]
//[assembly: AssemblyConfiguration("")]
//[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Jolt")]
[assembly: AssemblyCopyright("Copyright © Steve Guidi 2008")]
//[assembly: AssemblyTrademark("")]
//[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using0.3.* the '*' as shown below:
[assembly: AssemblyVersion("0.4.*")]
[assembly: AssemblyFileVersion("0.4.*")]

// Friend assemblies.
[assembly: InternalsVisibleTo("Jolt.Collections")]
[assembly: InternalsVisibleTo("Jolt.Test")]
[assembly: InternalsVisibleTo("Jolt.Testing")]
[assembly: InternalsVisibleTo("Jolt.Testing.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]