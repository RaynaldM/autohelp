// ----------------------------------------------------------------------------
// Enumerable.cs
//
// Contains the definition of the Enumerable class.
// Copyright 2010 Steve Guidi.
//
// File created: 2/12/2010 13:48:14
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Jolt.Functional;

namespace Jolt.Linq
{
    /// <summary>
    /// Defines extension methods for <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>
    /// </summary>
    public static class Enumerable
    {
        /// <summary>
        /// Creates an <see cref="IEnumerable&lt;T&gt;"/> that is not down-castable to its
        /// concrete collection type.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of element contained in the enumerator and source collection.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// The collection to adapt to the non-castable reference.
        /// </param>
        /// 
        /// <returns>
        /// A new <see cref="IEnumerable&lt;T&gt;"/> instance that provides a new enumerator
        /// to the given collection.
        /// </returns>
        public static IEnumerable<T> AsNonCastableEnumerable<T>(this IEnumerable<T> source)
        {
            return source.Select(Functor.Identity<T>());
        }
    }
}