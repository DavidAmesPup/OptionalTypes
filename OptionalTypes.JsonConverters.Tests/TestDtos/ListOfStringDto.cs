using System;
using System.Collections.Generic;

namespace OptionalTypes.JsonConverters.Tests.TestDtos
{
  
    public class ListOfStringDto
    {
        public Optional<List<string>> Values { get; set; }
    }
}