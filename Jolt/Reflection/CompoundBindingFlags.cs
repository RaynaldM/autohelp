// ----------------------------------------------------------------------------
// BindingBindingFlags.cs
//
// Contains the definition of the BindingFlags class.
// Copyright 2010 Steve Guidi.
//
// File created: 10/4/2010 23:21:56
// ----------------------------------------------------------------------------

using System.Reflection;

namespace Jolt.Reflection
{
    /// <summary>
    /// Defines common combinations of the <see cref="System.Reflection.BindingFlags"/> enumeration.
    /// </summary>
    public static class CompoundBindingFlags
    {
        /// <summary>
        /// Specifies that any public instance members are to be included in the search.
        /// </summary>
        public const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;

        /// <summary>
        /// Specifies that any public static members are to be included in the search.
        /// </summary>
        public const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;

        /// <summary>
        /// Specifies that any non-public instance members are to be included in the search.
        /// </summary>
        public const BindingFlags NonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Specifies that any non-public static members are to be included in the search.
        /// </summary>
        public const BindingFlags NonPublicStatic = BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        /// Specifies that any public or non-public static members are to be included in the search.
        /// </summary>
        public const BindingFlags AnyStatic = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        /// Specifies that any public or non-public instance members are to be included in the search.
        /// </summary>
        public const BindingFlags AnyInstance = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Specifies that any public or non-public, instance or static members are to be included in the search.
        /// </summary>
        public const BindingFlags Any = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
    }
}
        