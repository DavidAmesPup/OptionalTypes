﻿using System;

namespace Optionals.Types
{
    using System.Globalization;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Runtime;
    using System.Runtime.CompilerServices;
    using System.Security;


   // [Serializable]
    public struct Optional<T> //where T : struct
    {
        private bool isDefined;
        internal T value;

        public Optional(T value)
        {
            this.value = value;
            this.isDefined = true;
        }

        public bool IsDefined
        {
            get
            {
                return isDefined;
            }
        }

        public T Value
        {
            get
            {
                if (!isDefined)
                {
                    return default(T);

                    // throw new InvalidOperationException("No value specified");
                }
                return value;
            }
        }

        public T GetValueOrDefault()
        {
            return value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            return isDefined ? value : defaultValue;
        }

        public override bool Equals(object other)
        {

            if (other == null) return false;
            if (!(other is Optional<T>)) return false;

               
            var typedOther = (Optional<T>) other;

            if (!IsDefined && !typedOther.isDefined)
                return true;
          
            return value.Equals(((Optional<T>)other).Value);
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
            return isDefined ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return isDefined ? value.ToString() : "";
        }
        /*
         * public static implicit operator Null<T>(T value) {
	return new Null<T>(true, value);
}
These shown structures go into the "struct", just in case.

Implicit conversion to primitive type
The process logically should go both ways, and so there's this:

public static implicit operator T(Null<T> obj) {
	if (obj.hasValue) {
		return obj.value;
	} else throw new Exception("Value is null.");
}
         * 
         * */

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }

        public static explicit operator T(Optional<T> value)
        {
            return value.Value;
        }

        public static implicit operator Optional<T>(NoValue noValue)
        {
            return new Optional<T>(default(T));
        }
        public class NoValue { }

    }

    [System.Runtime.InteropServices.ComVisible(true)]
    public static class Optional
    {
        [System.Runtime.InteropServices.ComVisible(true)]
        public static int Compare<T>(Optional<T> n1, Optional<T> n2) where T : struct
        {
            if (n1.IsDefined)
            {
                if (n2.IsDefined) return Comparer<T>.Default.Compare(n1.value, n2.value);
                return 1;
            }
            if (n2.IsDefined) return -1;
            return 0;
        }

        [System.Runtime.InteropServices.ComVisible(true)]
        public static bool Equals<T>(Optional<T> n1, Optional<T> n2) where T : struct
        {
            if (n1.IsDefined)
            {
                if (n2.IsDefined) return EqualityComparer<T>.Default.Equals(n1.value, n2.value);
                return false;
            }
            if (n2.IsDefined) return false;
            return true;
        }

        // If the type provided is not a Optional Type, return null.
        // Otherwise, returns the underlying type of the Optional type
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
