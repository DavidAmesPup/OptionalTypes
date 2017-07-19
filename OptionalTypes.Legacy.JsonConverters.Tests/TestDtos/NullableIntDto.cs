using System;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class NullableDateTimeDto
    {
        public Optional<DateTime?> Value { get; set; }
    }
}