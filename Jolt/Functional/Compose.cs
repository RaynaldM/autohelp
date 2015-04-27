// ----------------------------------------------------------------------------
// Compose.cs
//
// Contains the definition of the Compose class.
// Copyright 2009 Steve Guidi.
//
// File created: 4/29/2009 08:04:49
// ----------------------------------------------------------------------------

using System;

namespace Jolt.Functional
{
    /// <summary>
    /// Provides factory methods for creating composite delegates.
    /// Each factory method binds the deferred execution of a given delegate
    /// as the argument of another delegate.
    /// </summary>
    public static class Compose
    {
        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f() equivalent to <paramref name="function"/>(<paramref name="value"/>()).
        /// </returns>
        public static Func<TResult> First<T, TResult>(Func<T, TResult> function, Func<T> value)
        {
            return () => function(value());
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s) equivalent to <paramref name="function"/>(<paramref name="value"/>(s)).
        /// </returns>
        public static Func<U, TResult> First<T, U, TResult>(Func<T, TResult> function, Func<U, T> value)
        {
            return u_arg => function(value(u_arg));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t)).
        /// </returns>
        public static Func<U1, U2, TResult> First<T, U1, U2, TResult>(Func<T, TResult> function, Func<U1, U2, T> value)
        {
            return (u_arg1, u_arg2) => function(value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Func<U1, U2, U3, TResult> First<T, U1, U2, U3, TResult>(Func<T, TResult> function, Func<U1, U2, U3, T> value)
        {
            return (u_arg1, u_arg2, u_arg3) => function(value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u ,v) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u ,v)).
        /// </returns>
        public static Func<U1, U2, U3, U4, TResult> First<T, U1, U2, U3, U4, TResult>(Func<T, TResult> function, Func<U1, U2, U3, U4, T> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4) => function(value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x).
        /// </returns>
        public static Func<T2, TResult> First<T1, T2, TResult>(Func<T1, T2, TResult> function, Func<T1> value)
        {
            return t_arg2 => function(value(), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x).
        /// </returns>
        public static Func<U, T2, TResult> First<T1, T2, U, TResult>(Func<T1, T2, TResult> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2) => function(value(u_arg), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x).
        /// </returns>
        public static Func<U1, U2, T2, TResult> First<T1, T2, U1, U2, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2) => function(value(u_arg1, u_arg2), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x).
        /// </returns>
        public static Func<U1, U2, U3, T2, TResult> First<T1, T2, U1, U2, U3, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2) => function(value(u_arg1, u_arg2, u_arg3), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x).
        /// </returns>
        public static Func<U1, U2, U3, U4, T2, TResult> First<T1, T2, U1, U2, U3, U4, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x, y).
        /// </returns>
        public static Func<T2, T3, TResult> First<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, Func<T1> value)
        {
            return (t_arg2, t_arg3) => function(value(), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x, y).
        /// </returns>
        public static Func<U, T2, T3, TResult> First<T1, T2, T3, U, TResult>(Func<T1, T2, T3, TResult> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2, t_arg3) => function(value(u_arg), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x, y).
        /// </returns>
        public static Func<U1, U2, T2, T3, TResult> First<T1, T2, T3, U1, U2, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2, t_arg3) => function(value(u_arg1, u_arg2), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x, y).
        /// </returns>
        public static Func<U1, U2, U3, T2, T3, TResult> First<T1, T2, T3, U1, U2, U3, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2, t_arg3) => function(value(u_arg1, u_arg2, u_arg3), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x, y).
        /// </returns>
        public static Func<U1, U2, U3, U4, T2, T3, TResult> First<T1, T2, T3, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2, t_arg3) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x, y, z).
        /// </returns>
        public static Func<T2, T3, T4, TResult> First<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<T1> value)
        {
            return (t_arg2, t_arg3, t_arg4) => function(value(), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x, y, z).
        /// </returns>
        public static Func<U, T2, T3, T4, TResult> First<T1, T2, T3, T4, U, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2, t_arg3, t_arg4) => function(value(u_arg), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x, y, z).
        /// </returns>
        public static Func<U1, U2, T2, T3, T4, TResult> First<T1, T2, T3, T4, U1, U2, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x, y, z).
        /// </returns>
        public static Func<U1, U2, U3, T2, T3, T4, TResult> First<T1, T2, T3, T4, U1, U2, U3, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2, u_arg3), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x, y, z).
        /// </returns>
        public static Func<U1, U2, U3, U4, T2, T3, T4, TResult> First<T1, T2, T3, T4, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f() equivalent to <paramref name="function"/>(<paramref name="value"/>()).
        /// </returns>
        public static Action First<T>(Action<T> function, Func<T> value)
        {
            return () => function(value());
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s) equivalent to <paramref name="function"/>(<paramref name="value"/>(s)).
        /// </returns>
        public static Action<U> First<T, U>(Action<T> function, Func<U, T> value)
        {
            return u_arg => function(value(u_arg));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t)).
        /// </returns>
        public static Action<U1, U2> First<T, U1, U2>(Action<T> function, Func<U1, U2, T> value)
        {
            return (u_arg1, u_arg2) => function(value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Action<U1, U2, U3> First<T, U1, U2, U3>(Action<T> function, Func<U1, U2, U3, T> value)
        {
            return (u_arg1, u_arg2, u_arg3) => function(value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u ,v) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u ,v)).
        /// </returns>
        public static Action<U1, U2, U3, U4> First<T, U1, U2, U3, U4>(Action<T> function, Func<U1, U2, U3, U4, T> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4) => function(value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x).
        /// </returns>
        public static Action<T2> First<T1, T2>(Action<T1, T2> function, Func<T1> value)
        {
            return t_arg2 => function(value(), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x).
        /// </returns>
        public static Action<U, T2> First<T1, T2, U>(Action<T1, T2> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2) => function(value(u_arg), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        ///
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x).
        /// </returns>
        public static Action<U1, U2, T2> First<T1, T2, U1, U2>(Action<T1, T2> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2) => function(value(u_arg1, u_arg2), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        ///
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x).
        /// </returns>
        public static Action<U1, U2, U3, T2> First<T1, T2, U1, U2, U3>(Action<T1, T2> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2) => function(value(u_arg1, u_arg2, u_arg3), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x).
        /// </returns>
        public static Action<U1, U2, U3, U4, T2> First<T1, T2, U1, U2, U3, U4>(Action<T1, T2> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x, y).
        /// </returns>
        public static Action<T2, T3> First<T1, T2, T3>(Action<T1, T2, T3> function, Func<T1> value)
        {
            return (t_arg2, t_arg3) => function(value(), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x, y).
        /// </returns>
        public static Action<U, T2, T3> First<T1, T2, T3, U>(Action<T1, T2, T3> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2, t_arg3) => function(value(u_arg), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x, y).
        /// </returns>
        public static Action<U1, U2, T2, T3> First<T1, T2, T3, U1, U2>(Action<T1, T2, T3> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2, t_arg3) => function(value(u_arg1, u_arg2), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x, y).
        /// </returns>
        public static Action<U1, U2, U3, T2, T3> First<T1, T2, T3, U1, U2, U3>(Action<T1, T2, T3> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2, t_arg3) => function(value(u_arg1, u_arg2, u_arg3), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x, y) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x, y).
        /// </returns>
        public static Action<U1, U2, U3, U4, T2, T3> First<T1, T2, T3, U1, U2, U3, U4>(Action<T1, T2, T3> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2, t_arg3) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2, t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(), x, y, z).
        /// </returns>
        public static Action<T2, T3, T4> First<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, Func<T1> value)
        {
            return (t_arg2, t_arg3, t_arg4) => function(value(), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s), x, y, z).
        /// </returns>
        public static Action<U, T2, T3, T4> First<T1, T2, T3, T4, U>(Action<T1, T2, T3, T4> function, Func<U, T1> value)
        {
            return (u_arg, t_arg2, t_arg3, t_arg4) => function(value(u_arg), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t), x, y, z).
        /// </returns>
        public static Action<U1, U2, T2, T3, T4> First<T1, T2, T3, T4, U1, U2>(Action<T1, T2, T3, T4> function, Func<U1, U2, T1> value)
        {
            return (u_arg1, u_arg2, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u), x, y, z).
        /// </returns>
        public static Action<U1, U2, U3, T2, T3, T4> First<T1, T2, T3, T4, U1, U2, U3>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2, u_arg3), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the first argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(s, t, u, v, x, y, z) equivalent to <paramref name="function"/>(<paramref name="value"/>(s, t, u, v), x, y, z).
        /// </returns>
        public static Action<U1, U2, U3, U4, T2, T3, T4> First<T1, T2, T3, T4, U1, U2, U3, U4>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, U4, T1> value)
        {
            return (u_arg1, u_arg2, u_arg3, u_arg4, t_arg2, t_arg3, t_arg4) => function(value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg2, t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w) equivalent to <paramref name="function"/>(w, <paramref name="value"/>()).
        /// </returns>
        public static Func<T1, TResult> Second<T1, T2, TResult>(Func<T1, T2, TResult> function, Func<T2> value)
        {
            return t_arg1 => function(t_arg1, value());
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s)).
        /// </returns>
        public static Func<T1, U, TResult> Second<T1, T2, U, TResult>(Func<T1, T2, TResult> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1) => function(t_arg1, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t)).
        /// </returns>
        public static Func<T1, U1, U2, TResult> Second<T1, T2, U1, U2, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2) => function(t_arg1, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Func<T1, U1, U2, U3, TResult> Second<T1, T2, U1, U2, U3, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v)).
        /// </returns>
        public static Func<T1, U1, U2, U3, U4, TResult> Second<T1, T2, U1, U2, U3, U4, TResult>(Func<T1, T2, TResult> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(), x).
        /// </returns>
        public static Func<T1, T3, TResult> Second<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, Func<T2> value)
        {
            return (t_arg1, t_arg3) => function(t_arg1, value(), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s), x).
        /// </returns>
        public static Func<T1, U, T3, TResult> Second<T1, T2, T3, U, TResult>(Func<T1, T2, T3, TResult> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1, t_arg3) => function(t_arg1, value(u_arg1), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        ///
        /// <returns>
        /// A functor f(w, s, t, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t), x).
        /// </returns>
        public static Func<T1, U1, U2, T3, TResult> Second<T1, T2, T3, U1, U2, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, t_arg3) => function(t_arg1, value(u_arg1, u_arg2), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u), x).
        /// </returns>
        public static Func<T1, U1, U2, U3, T3, TResult> Second<T1, T2, T3, U1, U2, U3, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, t_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v), x).
        /// </returns>
        public static Func<T1, U1, U2, U3, U4, T3, TResult> Second<T1, T2, T3, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4, t_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(), x, y).
        /// </returns>
        public static Func<T1, T3, T4, TResult> Second<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<T2> value)
        {
            return (t_arg1, t_arg3, t_arg4) => function(t_arg1, value(), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s), x, y).
        /// </returns>
        public static Func<T1, U, T3, T4, TResult> Second<T1, T2, T3, T4, U, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1, t_arg3, t_arg4) => function(t_arg1, value(u_arg1), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t), x, y).
        /// </returns>
        public static Func<T1, U1, U2, T3, T4, TResult> Second<T1, T2, T3, T4, U1, U2, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u), x, y).
        /// </returns>
        public static Func<T1, U1, U2, U3, T3, T4, TResult> Second<T1, T2, T3, T4, U1, U2, U3, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v), x, y).
        /// </returns>
        public static Func<T1, U1, U2, U3, U4, T3, T4, TResult> Second<T1, T2, T3, T4, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w) equivalent to <paramref name="function"/>(w, <paramref name="value"/>()).
        /// </returns>
        public static Action<T1> Second<T1, T2>(Action<T1, T2> function, Func<T2> value)
        {
            return t_arg1 => function(t_arg1, value());
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s)).
        /// </returns>
        public static Action<T1, U> Second<T1, T2, U>(Action<T1, T2> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1) => function(t_arg1, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t)).
        /// </returns>
        public static Action<T1, U1, U2> Second<T1, T2, U1, U2>(Action<T1, T2> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2) => function(t_arg1, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Action<T1, U1, U2, U3> Second<T1, T2, U1, U2, U3>(Action<T1, T2> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v)).
        /// </returns>
        public static Action<T1, U1, U2, U3, U4> Second<T1, T2, U1, U2, U3, U4>(Action<T1, T2> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(), x).
        /// </returns>
        public static Action<T1, T3> Second<T1, T2, T3>(Action<T1, T2, T3> function, Func<T2> value)
        {
            return (t_arg1, t_arg3) => function(t_arg1, value(), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s), x).
        /// </returns>
        public static Action<T1, U, T3> Second<T1, T2, T3, U>(Action<T1, T2, T3> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1, t_arg3) => function(t_arg1, value(u_arg1), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t), x).
        /// </returns>
        public static Action<T1, U1, U2, T3> Second<T1, T2, T3, U1, U2>(Action<T1, T2, T3> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, t_arg3) => function(t_arg1, value(u_arg1, u_arg2), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u), x).
        /// </returns>
        public static Action<T1, U1, U2, U3, T3> Second<T1, T2, T3, U1, U2, U3>(Action<T1, T2, T3> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, t_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v, x) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v), x).
        /// </returns>
        public static Action<T1, U1, U2, U3, U4, T3> Second<T1, T2, T3, U1, U2, U3, U4>(Action<T1, T2, T3> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4, t_arg3) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg3);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(), x, y).
        /// </returns>
        public static Action<T1, T3, T4> Second<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, Func<T2> value)
        {
            return (t_arg1, t_arg3, t_arg4) => function(t_arg1, value(), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s), x, y).
        /// </returns>
        public static Action<T1, U, T3, T4> Second<T1, T2, T3, T4, U>(Action<T1, T2, T3, T4> function, Func<U, T2> value)
        {
            return (t_arg1, u_arg1, t_arg3, t_arg4) => function(t_arg1, value(u_arg1), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t), x, y).
        /// </returns>
        public static Action<T1, U1, U2, T3, T4> Second<T1, T2, T3, T4, U1, U2>(Action<T1, T2, T3, T4> function, Func<U1, U2, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u), x, y).
        /// </returns>
        public static Action<T1, U1, U2, U3, T3, T4> Second<T1, T2, T3, T4, U1, U2, U3>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the second argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, s, t, u, v, x, y) equivalent to <paramref name="function"/>(w, <paramref name="value"/>(s, t, u, v), x, y).
        /// </returns>
        public static Action<T1, U1, U2, U3, U4, T3, T4> Second<T1, T2, T3, T4, U1, U2, U3, U4>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, U4, T2> value)
        {
            return (t_arg1, u_arg1, u_arg2, u_arg3, u_arg4, t_arg3, t_arg4) => function(t_arg1, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg3, t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>()).
        /// </returns>
        public static Func<T1, T2, TResult> Third<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, Func<T3> value)
        {
            return (t_arg1, t_arg2) => function(t_arg1, t_arg2, value());
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s)).
        /// </returns>
        public static Func<T1, T2, U, TResult> Third<T1, T2, T3, U, TResult>(Func<T1, T2, T3, TResult> function, Func<U, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1) => function(t_arg1, t_arg2, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t)).
        /// </returns>
        public static Func<T1, T2, U1, U2, TResult> Third<T1, T2, T3, U1, U2, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2) => function(t_arg1, t_arg2, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Func<T1, T2, U1, U2, U3, TResult> Third<T1, T2, T3, U1, U2, U3, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, v) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u, v)).
        /// </returns>
        public static Func<T1, T2, U1, U2, U3, U4, TResult> Third<T1, T2, T3, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, TResult> function, Func<U1, U2, U3, U4, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(), y).
        /// </returns>
        public static Func<T1, T2, T4, TResult> Third<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<T3> value)
        {
            return (t_arg1, t_arg2, t_arg4) => function(t_arg1, t_arg2, value(), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the rgument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s), y).
        /// </returns>
        public static Func<T1, T2, U, T4, TResult> Third<T1, T2, T3, T4, U, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, t_arg4) => function(t_arg1, t_arg2, value(u_arg1), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t), y).
        /// </returns>
        public static Func<T1, T2, U1, U2, T4, TResult> Third<T1, T2, T3, T4, U1, U2, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u), y).
        /// </returns>
        public static Func<T1, T2, U1, U2, U3, T4, TResult> Third<T1, T2, T3, T4, U1, U2, U3, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, v, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u, v), y).
        /// </returns>
        public static Func<T1, T2, U1, U2, U3, U4, T4, TResult> Third<T1, T2, T3, T4, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, U4, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, u_arg4, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>()).
        /// </returns>
        public static Action<T1, T2> Third<T1, T2, T3>(Action<T1, T2, T3> function, Func<T3> value)
        {
            return (t_arg1, t_arg2) => function(t_arg1, t_arg2, value());
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s)).
        /// </returns>
        public static Action<T1, T2, U> Third<T1, T2, T3, U>(Action<T1, T2, T3> function, Func<U, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1) => function(t_arg1, t_arg2, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t)).
        /// </returns>
        public static Action<T1, T2, U1, U2> Third<T1, T2, T3, U1, U2>(Action<T1, T2, T3> function, Func<U1, U2, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2) => function(t_arg1, t_arg2, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u)).
        /// </returns>
        public static Action<T1, T2, U1, U2, U3> Third<T1, T2, T3, U1, U2, U3>(Action<T1, T2, T3> function, Func<U1, U2, U3, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, v) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u, v)).
        /// </returns>
        public static Action<T1, T2, U1, U2, U3, U4> Third<T1, T2, T3, U1, U2, U3, U4>(Action<T1, T2, T3> function, Func<U1, U2, U3, U4, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(), y).
        /// </returns>
        public static Action<T1, T2, T4> Third<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, Func<T3> value)
        {
            return (t_arg1, t_arg2, t_arg4) => function(t_arg1, t_arg2, value(), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s), y).
        /// </returns>
        public static Action<T1, T2, U, T4> Third<T1, T2, T3, T4, U>(Action<T1, T2, T3, T4> function, Func<U, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, t_arg4) => function(t_arg1, t_arg2, value(u_arg1), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t), y).
        /// </returns>
        public static Action<T1, T2, U1, U2, T4> Third<T1, T2, T3, T4, U1, U2>(Action<T1, T2, T3, T4> function, Func<U1, U2, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u), y).
        /// </returns>
        public static Action<T1, T2, U1, U2, U3, T4> Third<T1, T2, T3, T4, U1, U2, U3>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the third argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, s, t, u, v, y) equivalent to <paramref name="function"/>(w, x, <paramref name="value"/>(s, t, u, v), y).
        /// </returns>
        public static Action<T1, T2, U1, U2, U3, U4, T4> Third<T1, T2, T3, T4, U1, U2, U3, U4>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, U4, T3> value)
        {
            return (t_arg1, t_arg2, u_arg1, u_arg2, u_arg3, u_arg4, t_arg4) => function(t_arg1, t_arg2, value(u_arg1, u_arg2, u_arg3, u_arg4), t_arg4);
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>()).
        /// </returns>
        public static Func<T1, T2, T3, TResult> Fourth<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<T4> value)
        {
            return (t_arg1, t_arg2, t_arg3) => function(t_arg1, t_arg2, t_arg3, value());
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s)).
        /// </returns>>
        public static Func<T1, T2, T3, U, TResult> Fourth<T1, T2, T3, T4, U, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1) => function(t_arg1, t_arg2, t_arg3, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t)).
        /// </returns>>
        public static Func<T1, T2, T3, U1, U2, TResult> Fourth<T1, T2, T3, T4, U1, U2, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t, u) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t, u)).
        /// </returns>>
        public static Func<T1, T2, T3, U1, U2, U3, TResult> Fourth<T1, T2, T3, T4, U1, U2, U3, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2, u_arg3) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        ///
        /// <typeparam name="TResult">
        /// The type of the function-to-bind's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t, u, v) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t, u, v)).
        /// </returns>>
        public static Func<T1, T2, T3, U1, U2, U3, U4, TResult> Fourth<T1, T2, T3, T4, U1, U2, U3, U4, TResult>(Func<T1, T2, T3, T4, TResult> function, Func<U1, U2, U3, U4, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a zero-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>()).
        /// </returns>
        public static Action<T1, T2, T3> Fourth<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, Func<T4> value)
        {
            return (t_arg1, t_arg2, t_arg3) => function(t_arg1, t_arg2, t_arg3, value());
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a one-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U">
        /// The type of the argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s)).
        /// </returns>>
        public static Action<T1, T2, T3, U> Fourth<T1, T2, T3, T4, U>(Action<T1, T2, T3, T4> function, Func<U, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1) => function(t_arg1, t_arg2, t_arg3, value(u_arg1));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a two-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t)).
        /// </returns>>
        public static Action<T1, T2, T3, U1, U2> Fourth<T1, T2, T3, T4, U1, U2>(Action<T1, T2, T3, T4> function, Func<U1, U2, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a three-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t, u) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t, u)).
        /// </returns>>
        public static Action<T1, T2, T3, U1, U2, U3> Fourth<T1, T2, T3, T4, U1, U2, U3>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2, u_arg3) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2, u_arg3));
        }

        /// <summary>
        /// Composes two functions by binding the fourth argument of
        /// a given function to a four-argument function.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T3">
        /// The type of the third argument of the function-to-bind.
        /// </typeparam>
        ///
        /// <typeparam name="T4">
        /// The type of the fourth argument of the function-to-bind.
        /// </typeparam>
        /// 
        /// <typeparam name="U1">
        /// The type of the first argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U2">
        /// The type of the second argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U3">
        /// The type of the third argument of the inner function.
        /// </typeparam>
        /// 
        /// <typeparam name="U4">
        /// The type of the fourth argument of the inner function.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to bind to.
        /// </param>
        /// 
        /// <param name="value">
        /// The inner function that participates in the composite.
        /// </param>
        /// 
        /// <returns>
        /// A functor f(w, x, y, s, t, u, v) equivalent to <paramref name="function"/>(w, x, y, <paramref name="value"/>(s, t, u, v)).
        /// </returns>>
        public static Action<T1, T2, T3, U1, U2, U3, U4> Fourth<T1, T2, T3, T4, U1, U2, U3, U4>(Action<T1, T2, T3, T4> function, Func<U1, U2, U3, U4, T4> value)
        {
            return (t_arg1, t_arg2, t_arg3, u_arg1, u_arg2, u_arg3, u_arg4) => function(t_arg1, t_arg2, t_arg3, value(u_arg1, u_arg2, u_arg3, u_arg4));
        }
    }
}