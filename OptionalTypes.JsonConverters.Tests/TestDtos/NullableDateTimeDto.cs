using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class NullableIntDto
    {
        public Optional<int?> Value { get; set; }
    }
}
