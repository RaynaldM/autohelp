// ----------------------------------------------------------------------------
// ExceptionUtility.cs
//
// Contains the definition of the ExceptionUtility class.
// Copyright 2010 Steve Guidi.
//
// File created: 10/1/2010 09:20:45
// ----------------------------------------------------------------------------

using System;

namespace Jolt
{
    /// <summary>
    /// Facilitates the construction of exceptions in common operations.
    /// </summary>
    internal static class ExceptionUtility
    {
        /// <summary>
        /// Raises an <see cref="System.ArgumentNullException"/> when the given argument is null.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument to validate.
        /// </typeparam>
        /// 
        /// <param name="argument">
        /// The argument to validate.
        /// </param>
        /// 
        /// <remarks>
        /// Use this overload when there is only one argument in a function that is being validated.
        /// </remarks>
        internal static void ThrowOnNullArgument<T>(T argument)
            where T : class
        {
            ThrowOnNullArgument(argument, string.Empty);
        }

        /// <summary>
        /// Raises an <see cref="System.ArgumentNullException"/> when the given argument is null.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument to validate.
        /// </typeparam>
        /// 
        /// <param name="argument">
        /// The argument to validate.
        /// </param>
        /// 
        /// <param name="argumentName">
        /// The name of the argument that is null.
        /// </param>
        internal static void ThrowOnNullArgument<T>(T argument, string argumentName)
            where T : class
        {
            if (argument == null) { throw new ArgumentNullException(argumentName); }
        }
    }
}