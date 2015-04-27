// ----------------------------------------------------------------------------
// MethodNames.cs
//
// Contains the definition of the MethodNames class.
// Copyright 2010 Steve Guidi.
//
// File created: 10/19/2010 14:42:50
// ----------------------------------------------------------------------------

namespace Jolt.Reflection
{
    /// <summary>
    /// Defines string constants representing the CLS-compliant method name
    /// prefixes for special method types.
    /// </summary>
    public static class MethodPrefixes
    {
        public const string PropertyGet = "get_";
        public const string PropertySet = "set_";
        public const string EventSubscribe = "add_";
        public const string EventUnsubscribe = "remove_";
        public const string EventRaise = "raise_";
        public const string Operator = "op_";
    }
}