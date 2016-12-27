using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionalTypes
{
    public interface IOptional
    {
        bool IsDefined { get; }
        object Value { get;  }
    }
}
