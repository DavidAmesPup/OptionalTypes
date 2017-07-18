using System;


namespace OptionalTypes
{
    public interface IOptional
    {
        bool IsDefined { get; }
        object Value { get;  }
        Type GetUnderlyingType();
        Type GetBaseType();
    }
}
