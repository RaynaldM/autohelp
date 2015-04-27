// ----------------------------------------------------------------------------
// Functor.cs
//
// Contains the definition of the Functor class.
// Copyright 2009 Steve Guidi.
//
// File created: 3/17/2009 03:34:45
// ----------------------------------------------------------------------------

using System;

namespace Jolt.Functional
{
    /// <summary>
    /// Provides methods for transforming delegates, and creating
    /// delegates that perform common operations.
    /// </summary>
    public static class Functor
    {
        /// <summary>
        /// Adapts a <see cref="System.Func&lt;TResult&gt;"/> delegate to the corresponding
        /// <see cref="System.Action"/> delegate by ignoring the
        /// <see cref="System.Func&lt;T&gt;"/> return value.
        /// </summary>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to adapt.
        /// </param>
        /// 
        /// <returns>
        /// The <see cref="System.Action"/> that adapts <paramref name="function"/>.
        /// </returns>
        public static Action ToAction<TResult>(Func<TResult> function)
        {
            return () => function();
        }

        /// <summary>
        /// Adapts a <see cref="System.Func&lt;T, TResult&gt;"/> delegate to the corresponding
        /// <see cref="System.Action&lt;T&gt;"/> delegate by ignoring the
        /// <see cref="System.Func&lt;T, TResult&gt;"/> return value.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to adapt.
        /// </param>
        /// 
        /// <returns>
        /// The <see cref="System.Action&lt;T&gt;"/> that adapts <paramref name="function"/>.
        /// </returns>
        public static Action<T> ToAction<T, TResult>(Func<T, TResult> function)
        {
            return arg => function(arg);
        }

        /// <summary>
        /// Adapts a <see cref="System.Func&lt;T1, T2, TResult&gt;"/> delegate to the corresponding
        /// <see cref="System.Action&lt;T1, T2&gt;"/> delegate by ignoring the
        /// <see cref="System.Func&lt;T1, T2, TResult&gt;"/> return value.
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
        /// The function to adapt.
        /// </param>
        /// 
        /// <returns>
        /// The <see cref="System.Action&lt;T1, T2&gt;"/> that adapts <paramref name="function"/>.
        /// </returns>
        public static Action<T1, T2> ToAction<T1, T2, TResult>(Func<T1, T2, TResult> function)
        {
            return (arg1, arg2) => function(arg1, arg2);
        }

        /// <summary>
        /// Adapts a <see cref="System.Func&lt;T1, T2, T3, TResult&gt;"/> delegate to the corresponding
        /// <see cref="System.Action&lt;T1, T2, T3&gt;"/> delegate by ignoring the
        /// <see cref="System.Func&lt;T1, T2, T3, TResult&gt;"/> return value.
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
        /// The function to adapt.
        /// </param>
        /// 
        /// <returns>
        /// The <see cref="System.Action&lt;T1, T2, T3&gt;"/> that adapts <paramref name="function"/>.
        /// </returns>
        public static Action<T1, T2, T3> ToAction<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function)
        {
            return (arg1, arg2, arg3) => function(arg1, arg2, arg3);
        }

        /// <summary>
        /// Adapts a <see cref="System.Func&lt;T1, T2, T3, T4, TResult&gt;"/> delegate to the corresponding
        /// <see cref="System.Action&lt;T1, T2, T3, T4&gt;"/> delegate by ignoring the
        /// <see cref="System.Func&lt;T1, T2, T3, T4, TResult&gt;"/> return value.
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
        /// The function to adapt.
        /// </param>
        /// 
        /// <returns>
        /// The <see cref="System.Action&lt;T1, T2, T3, T4&gt;"/> that adapts <paramref name="function"/>.
        /// </returns>
        public static Action<T1, T2, T3, T4> ToAction<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function)
        {
            return (arg1, arg2, arg3, arg4) => function(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Adapts a generic EventHandler delegate to the corresponding
        /// Action delegate.
        /// </summary>
        /// 
        /// <typeparam name="TEventArgs">
        /// The type of the event handler argument.
        /// </typeparam>
        /// 
        /// <param name="eventHandler">
        /// The event handler to adapt.
        /// </param>
        public static Action<object, TEventArgs> ToAction<TEventArgs>(EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            return Delegate.CreateDelegate(typeof(Action<object, TEventArgs>), eventHandler.Target, eventHandler.Method) as Action<object, TEventArgs>;
        }

        /// <summary>
        /// Adapts an Action delegate to a generic EventHandler delegate.
        /// </summary>
        /// 
        /// <typeparam name="TEventArgs">
        /// The type of the event handler argument.
        /// </typeparam>
        /// 
        /// <param name="action">
        /// The action handler to adapt.
        /// </param>
        public static EventHandler<TEventArgs> ToEventHandler<TEventArgs>(Action<object, TEventArgs> action)
            where TEventArgs : EventArgs
        {
            return Delegate.CreateDelegate(typeof(EventHandler<TEventArgs>), action.Target, action.Method) as EventHandler<TEventArgs>;
        }

        /// <summary>
        /// Adapts a Func delegate to the corresponding Predicate delegate.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the predicate argument.
        /// </typeparam>
        /// 
        /// <param name="function">
        /// The function to adapt.
        /// </param>
        public static Predicate<T> ToPredicate<T>(Func<T, bool> function)
        {
            return Delegate.CreateDelegate(typeof(Predicate<T>), function.Target, function.Method) as Predicate<T>;
        }

        /// <summary>
        /// Adapts a Predicate delegate to the corresponding Func delegate.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the predicate argument.
        /// </typeparam>
        /// 
        /// <param name="predicate">
        /// The predicate to adapt.
        /// </param>
        public static Func<T, bool> ToPredicateFunc<T>(Predicate<T> predicate)
        {
            return Delegate.CreateDelegate(typeof(Func<T, bool>), predicate.Target, predicate.Method) as Func<T, bool>;
        }

        /// <summary>
        /// Creates a functor that returns a constant value for any input.
        /// </summary>
        /// 
        /// <typeparam name="TResult">
        /// The type of the function's return value.
        /// </typeparam>
        /// 
        /// <param name="value">
        /// The constant return value.
        /// </param>
        public static Func<TResult> Idempotency<TResult>(TResult value)
        {
            return delegate { return value; };
        }

        /// <summary>
        /// Creates a functor that returns a constant value for any input.
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
        /// <param name="value">
        /// The constant return value.
        /// </param>
        public static Func<T, TResult> Idempotency<T, TResult>(TResult value)
        {
            return delegate { return value; };
        }

        /// <summary>
        /// Creates a functor that returns a constant value for any input.
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
        /// <param name="value">
        /// The constant return value.
        /// </param>
        public static Func<T1, T2, TResult> Idempotency<T1, T2, TResult>(TResult value)
        {
            return delegate { return value; };
        }

        /// <summary>
        /// Creates a functor that returns a constant value for any input.
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
        /// <param name="value">
        /// The constant return value.
        /// </param>
        public static Func<T1, T2, T3, TResult> Idempotency<T1, T2, T3, TResult>(TResult value)
        {
            return delegate { return value; };
        }

        /// <summary>
        /// Creates a functor that returns a constant value for any input.
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
        /// <param name="value">
        /// The constant return value.
        /// </param>
        public static Func<T1, T2, T3, T4, TResult> Idempotency<T1, T2, T3, T4, TResult>(TResult value)
        {
            return delegate { return value; };
        }

        /// <summary>
        /// Creates a functor that returns immediately, performing no operation.
        /// </summary>
        public static Action NoOperation()
        {
            return delegate { };
        }

        /// <summary>
        /// Creates a functor that returns immediately, performing no operation.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument.
        /// </typeparam>
        public static Action<T> NoOperation<T>()
        {
            return delegate { };
        }

        /// <summary>
        /// Creates a functor that returns immediately, performing no operation.
        /// </summary>
        /// 
        /// <typeparam name="T1">
        /// The type of the first function argument.
        /// </typeparam>
        /// 
        /// <typeparam name="T2">
        /// The type of the second function argument.
        /// </typeparam>
        public static Action<T1, T2> NoOperation<T1, T2>()
        {
            return delegate { };
        }

        /// <summary>
        /// Creates a functor that returns immediately, performing no operation.
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
        public static Action<T1, T2, T3> NoOperation<T1, T2, T3>()
        {
            return delegate { };
        }

        /// <summary>
        /// Creates a functor that returns immediately, performing no operation.
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
        public static Action<T1, T2, T3, T4> NoOperation<T1, T2, T3, T4>()
        {
            return delegate { };
        }

        /// <summary>
        /// Creates an identity function, returning its given argument.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument and return value.
        /// </typeparam>
        public static Func<T, T> Identity<T>()
        {
            return arg => arg;
        }

        /// <summary>
        /// Creates a predicate that returns true for any input.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument.
        /// </typeparam>
        public static Func<T, bool> TrueForAll<T>()
        {
            return delegate { return true; };   // Ensures the generated method is static.
        }

        /// <summary>
        /// Creates a predicate that returns false for any input.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the function argument.
        /// </typeparam>
        public static Func<T, bool> FalseForAll<T>()
        {
            return delegate { return false; };  // Ensures the generated method is static.
        }
    }
}