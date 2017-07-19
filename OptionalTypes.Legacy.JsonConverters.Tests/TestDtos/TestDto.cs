using System;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class TestDto
    {
        public Optional<string> AString { get; set; }
        public Optional<long?> ANullableLong { get; set; }
        public Optional<long?> ALong { get; set; }

        public Optional<int?> ANullableInt { get; set; }
        public Optional<int> AInt { get; set; }

        public Optional<DateTime> ADateTime { get; set; }
        public Optional<DateTime?> ANullableDateTime { get; set; }
    }
}