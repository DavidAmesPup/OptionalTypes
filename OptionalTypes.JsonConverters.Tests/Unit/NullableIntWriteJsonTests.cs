using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;
using OptionalTypes.JsonConverters;

namespace OptionalTypes.JsonConverters.Tests.Unit
{
    public static class NullableIntWriteJsonTests
    {

        private static StringWriter SerializeDto(object dto)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new OptionalConverter());
            StringWriter stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(stringWriter);

            jsonSerializer.Serialize(jsonWriter, dto);

            return stringWriter;

        }

        [Fact]
        public static void CanWriteNullableIntWithValue()
        {
            //Arrange
            NullableIntDto dto = new NullableIntDto()
            {
                Value = 5
            };

            //Act
            StringWriter sw = SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":5}", sw.ToString());
        }


        [Fact]
        public static void CanWriteNullForNullableIntWithNullValue()
        {
            //Arrange
            NullableIntDto dto = new NullableIntDto()
            {
                Value = null
            };

            //Act
            StringWriter sw = SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":null}", sw.ToString());
        }

        [Fact]
        public static void CanWriteUndefinedForNullableIntWithNoValue()
        {
            //Arrange
            NullableIntDto dto = new NullableIntDto();
            

            //Act
            StringWriter sw = SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
