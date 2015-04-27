// ----------------------------------------------------------------------------
// MethodResolver.cs
//
// Contains the definition of the MethodResolver class.
// Copyright 2010 Steve Guidi.
//
// File created: 9/29/2010 20:11:59
// ----------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Jolt.Reflection
{
    /// <summary>
    /// Provides methods to determine if a given <see cref="System.Reflection.MethodInfo"/> participates
    /// as part of another .NET method-like structure (i.e. properties, events).
    /// </summary>
    public static class MethodResolver
    {
        #region public methods --------------------------------------------------------------------

        /// <summary>
        /// Gets the <see cref="System.Reflection.PropertyInfo"/> that encapsulates the
        /// given method.
        /// </summary>
        /// 
        /// <param name="method">
        /// The <see cref="System.Reflection.MethodInfo"/> that is called as part of the
        /// property implementation.
        /// </param>
        /// 
        /// <param name="searchOtherMethods">
        /// Determines if the property methods listed as "other" are included in the search
        /// (analogous to the methods that follow the ".other" IL token).
        /// </param>
        /// 
        /// <returns>
        /// Returns the <see cref="System.Reflection.ParameterInfo"/> object that uses
        /// <paramref name="method"/> as its get, set, or other method (if specified).
        /// Returns NULL if such a property does not exist.
        /// </returns>
        /// 
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="method"/> is null.
        /// </exception>
        public static PropertyInfo GetProperty(MethodInfo method, bool searchOtherMethods)
        {
            ExceptionUtility.ThrowOnNullArgument(method);
            Predicate<PropertyInfo> isPropertyMethod =
                p => method.Equals(p.GetGetMethod(true)) ||
                     method.Equals(p.GetSetMethod(true));

            if (searchOtherMethods)
            {
                isPropertyMethod = p => Array.IndexOf(p.GetAccessors(true), method) >= 0;
            }

            return Array.Find(
                method.DeclaringType.GetProperties(CompoundBindingFlags.Any),
                isPropertyMethod);
        }

        /// <summary>
        /// Gets the <see cref="System.Reflection.PropertyInfo"/> that encapsulates the
        /// given method.
        /// </summary>
        /// 
        /// <param name="method">
        /// The <see cref="System.Reflection.MethodInfo"/> that is called as part of the
        /// property implementation.
        /// </param>
        /// 
        /// <returns>
        /// Returns the <see cref="System.Reflection.ParameterInfo"/> object that uses
        /// <paramref name="method"/> as its get, or set method.
        /// Returns NULL if such a property does not exist.
        /// </returns>
        /// 
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="method"/> is null.
        /// </exception>
        public static PropertyInfo GetProperty(MethodInfo method)
        {
            return GetProperty(method, false);
        }
        
        /// <summary>
        /// Gets the <see cref="System.Reflection.EventInfo"/> that encapsulates the
        /// given method.
        /// </summary>
        /// 
        /// <param name="method">
        /// The <see cref="System.Reflection.MethodInfo"/> that is called as part of the
        /// event implementation.
        /// </param>
        /// 
        /// <param name="searchOtherMethods">
        /// Determines if the property methods listed as "other" are included in the search
        /// (analogous to the methods that follow the ".other" IL token).
        /// </param>
        ///
        /// <returns>
        /// Returns the <see cref="System.Reflection.EventInfo"/> object that uses
        /// <paramref name="method"/> as its add, remove, raise, or other method (if specified).
        /// Returns NULL if such an event does not exist.
        /// </returns>
        /// 
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="method"/> is null.
        /// </exception>
        public static EventInfo GetEvent(MethodInfo method, bool searchOtherMethods)
        {
            ExceptionUtility.ThrowOnNullArgument(method);
            return Array.Find(
                method.DeclaringType.GetEvents(CompoundBindingFlags.Any),
                e => method.Equals(e.GetAddMethod(true)) ||
                     method.Equals(e.GetRemoveMethod(true)) ||
                     method.Equals(e.GetRaiseMethod(true)) ||
                     (searchOtherMethods && Array.IndexOf(e.GetOtherMethods(true), method) >= 0));
        }

        /// <summary>
        /// Gets the <see cref="System.Reflection.EventInfo"/> that encapsulates the
        /// given method.
        /// </summary>
        /// 
        /// <param name="method">
        /// The <see cref="System.Reflection.MethodInfo"/> that is called as part of the
        /// event implementation.
        /// </param>
        /// 
        /// <returns>
        /// Returns the <see cref="System.Reflection.EventInfo"/> object that uses
        /// <paramref name="method"/> as its add, remove, or raise method.
        /// Returns NULL if such an event does not exist.
        /// </returns>
        /// 
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="method"/> is null.
        /// </exception>
        public static EventInfo GetEvent(MethodInfo method)
        {
            return GetEvent(method, false);
        }

        #endregion
    }
}