using System.Collections.Generic;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
    public class ListOfDtosDto
    {
        public Optional<List<IntDto>> Values { get; set; }
    }
}