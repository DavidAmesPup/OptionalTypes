using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionalTypes;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class BoolDto
    {
        public Optional<bool> Value { get; set; }
    }
}
