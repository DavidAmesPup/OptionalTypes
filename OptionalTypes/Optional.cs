﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

//using System.Runtime.Serialization;
/*
 * http://www.paraesthesia.com/archive/2015/02/13/advanced-object-serialization-in-web-api/
 */

namespace OptionalTypes
{
    // [Serializable]
    public struct Optional<T> : IOptional
    {
        // ReSharper disable once InconsistentNaming
        internal readonly T value;

        public Optional(T value)
        {
            this.value = value;
            IsDefined = true;
        }


        public bool IsDefined { get; }

        public T Value
        {
            get
            {
                if (!IsDefined)
                    return default(T);
                return value;
            }
        }

        object IOptional.Value
        {
            get
            {
                if (!IsDefined)
                    return default(T);

                return value;
            }
        }

        public T GetValueOrDefault()
        {
            return value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            return IsDefined ? value : defaultValue;
        }

        public override bool Equals(object other)
        {
            if (IsDifferentTypeOfOptional(other)) return false;

            if (other is Optional<T>)
            {
                var typedOther = (Optional<T>)other; 
                if (!IsDefined && !typedOther.IsDefined)
                    return true;

                if (!IsDefined || !typedOther.IsDefined)
                    return false;

                if (ReferenceEquals(value, null))
                {
                    return ReferenceEquals(typedOther.Value, null);
                }

                return value.Equals(typedOther.Value);
            }

            if (!IsDefined)
                return true;

            if (ReferenceEquals(value, null))
            {
                return ReferenceEquals(other, null);
            }
            

            return value.Equals(other);
        }

        private static bool IsDifferentTypeOfOptional(object other)
        {
            if (!(other is Optional<T>))
            {
                if (!ReferenceEquals(other, null))
                {
                    var otherType = other.GetType();

                    if (otherType.GetTypeInfo().IsGenericType && otherType.GetGenericTypeDefinition() == typeof(Optional<>))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Match(Action<T> onMatched,
            Action onNotMatched = null)
        {
            if (IsDefined)
                onMatched(value);
            else
                onNotMatched?.Invoke();
        }


        public static bool operator ==(Optional<T> a,
            Optional<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Optional<T> a,
            Optional<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return IsDefined ? value.GetHashCode() : 0;
        }

        public Type GetBaseType()
        {
            return typeof(T);
        }

        public Type GetUnderlyingType()
        {
            var t = typeof(T);

            if (t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                t = Nullable.GetUnderlyingType(t);

            return t;
        }


        public override string ToString()
        {
            return IsDefined ? value == null ? string.Empty : value.ToString() : string.Empty;
        }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }


        public static explicit operator T(Optional<T> value)
        {
            return value.Value;
        }
    }

    [ComVisible(true)]
    public static class Optional
    {
        [ComVisible(true)]
        public static int Compare<T>(Optional<T> n1,
            Optional<T> n2) where T : struct
        {
            if (n1.IsDefined)
            {
                if (n2.IsDefined) return Comparer<T>.Default.Compare(n1.value, n2.value);
                return 1;
            }
            if (n2.IsDefined) return -1;
            return 0;
        }

        [ComVisible(true)]
        public static bool Equals<T>(Optional<T> n1,
            Optional<T> n2) where T : struct
        {
            if (n1.IsDefined)
            {
                if (n2.IsDefined) return EqualityComparer<T>.Default.Equals(n1.value, n2.value);
                return false;
            }
            if (n2.IsDefined) return false;
            return true;
        }

        // Otherwise, returns the underlying type of the Optional type

        // If the type provided is not a Optional Type, return null.
        /*
        public static Type GetUnderlyingType(Type optionalType)
        {
            if ((object)optionalType == null)
            {
                throw new ArgumentNullException(nameof(optionalType));
            }
        
            Type result = null;
            if (optionalType.IsGenericType && !optionalType.IsGenericTypeDefinition)
            {
                // instantiated generic type only                
                Type genericType = optionalType.GetGenericTypeDefinition();
                if (Object.ReferenceEquals(genericType, typeof(Optional<>)))
                {
                    result = optionalType.GetGenericArguments()[0];
                }
            }
            return result;
        }
        */
    }
}