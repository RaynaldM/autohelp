// ----------------------------------------------------------------------------
// Bind.cs
//
// Contains the definition of the Bind class.
// Copyright 2009 Steve Guidi.
//
// File created: 3/16/2009 22:34:13
// ----------------------------------------------------------------------------

using System;

namespace Jolt.Functional
{
    /// <summary>
    /// Provides factory methods that create delegates with select arguments
    /// bound to constant values.
    /// </summary>
    public static class Bind
    {
        /// <summary>
        /// Binds the argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f() equivalent to <paramref name="function"/>(<paramref name="value"/>).
        /// </returns>
        public static Func<TResult> First<T, TResult>(Func<T, TResult> function, T value)
        {
            return () => function(value);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(<paramref name="value"/>, x).
        /// </returns>
        public static Func<T2, TResult> First<T1, T2, TResult>(Func<T1, T2, TResult> function, T1 value)
        {
            return t_arg2 => function(value, t_arg2);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>, x, y).
        /// </returns>
        public static Func<T2, T3, TResult> First<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T1 value)
        {
            return (arg2, arg3) => function(value, arg2, arg3);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>, x, y, z).
        /// </returns>
        public static Func<T2, T3, T4, TResult> First<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T1 value)
        {
            return (arg2, arg3, arg4) => function(value, arg2, arg3, arg4);
        }

        /// <summary>
        /// Binds the argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f() equivalent to <paramref name="function"/>(<paramref name="value"/>).
        /// </returns>
        public static Action First<T>(Action<T> function, T value)
        {
            return () => function(value);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(<paramref name="value"/>, x).
        /// </returns>
        public static Action<T2> First<T1, T2>(Action<T1, T2> function, T1 value)
        {
            return t_arg2 => function(value, t_arg2);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>, x, y).
        /// </returns>
        public static Action<T2, T3> First<T1, T2, T3>(Action<T1, T2, T3> function, T1 value)
        {
            return (t_arg2, t_arg3) => function(value, t_arg2, t_arg3);
        }

        /// <summary>
        /// Binds the first argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>, x, y, z).
        /// </returns>
        public static Action<T2, T3, T4> First<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T1 value)
        {
            return (arg2, arg3, arg4) => function(value, arg2, arg3, arg4);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(x, <paramref name="value"/>).
        /// </returns>
        public static Func<T1, TResult> Second<T1, T2, TResult>(Func<T1, T2, TResult> function, T2 value)
        {
            return arg1 => function(arg1, value);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(x, <paramref name="value"/>, y).
        /// </returns>
        public static Func<T1, T3, TResult> Second<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T2 value)
        {
            return (arg1, arg3) => function(arg1, value, arg3);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, <paramref name="value"/>, y, z).
        /// </returns>
        public static Func<T1, T3, T4, TResult> Second<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T2 value)
        {
            return (arg1, arg3, arg4) => function(arg1, value, arg3, arg4);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(x, <paramref name="value"/>).
        /// </returns>
        public static Action<T1> Second<T1, T2>(Action<T1, T2> function, T2 value)
        {
            return arg1 => function(arg1, value);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(x, <paramref name="value"/>, y).
        /// </returns>
        public static Action<T1, T3> Second<T1, T2, T3>(Action<T1, T2, T3> function, T2 value)
        {
            return (arg1, arg3) => function(arg1, value, arg3);
        }

        /// <summary>
        /// Binds the second argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, <paramref name="value"/>, y, z).
        /// </returns>
        public static Action<T1, T3, T4> Second<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T2 value)
        {
            return (arg1, arg3, arg4) => function(arg1, value, arg3, arg4);
        }

        /// <summary>
        /// Binds the third argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(x, y, <paramref name="value"/>).
        /// </returns>
        public static Func<T1, T2, TResult> Third<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T3 value)
        {
            return (arg1, arg2) => function(arg1, arg2, value);
        }

        /// <summary>
        /// Binds the third argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, y, <paramref name="value"/>, z).
        /// </returns>
        public static Func<T1, T2, T4, TResult> Third<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T3 value)
        {
            return (arg1, arg2, arg4) => function(arg1, arg2, value, arg4);
        }

        /// <summary>
        /// Binds the third argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(x, y, <paramref name="value"/>).
        /// </returns>
        public static Action<T1, T2> Third<T1, T2, T3>(Action<T1, T2, T3> function, T3 value)
        {
            return (arg1, arg2) => function(arg1, arg2, value);
        }

        /// <summary>
        /// Binds the third argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, y, <paramref name="value"/>, z).
        /// </returns>
        public static Action<T1, T2, T4> Third<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T3 value)
        {
            return (arg1, arg2, arg4) => function(arg1, arg2, value, arg4);
        }

        /// <summary>
        /// Binds the fourth argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, y, z, <paramref name="value"/>).
        /// </returns>
        public static Func<T1, T2, T3, TResult> Fourth<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T4 value)
        {
            return (arg1, arg2, arg3) => function(arg1, arg2, arg3, value);
        }

        /// <summary>
        /// Binds the third argument of a given function to a given value.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T3">
        /// The type of the third function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T4">
        /// The type of the fourth function argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to bind.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(x, y, z, <paramref name="value"/>).
        /// </returns>
        public static Action<T1, T2, T3> Fourth<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T4 value)
        {
            return (arg1, arg2, arg3) => function(arg1, arg2, arg3, value);
        }
    }
}