using System;
using System.IO;
using Newtonsoft.Json;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class DateTimeTests
    {
        [Fact]
        public static void CanObeyDateFormatSettings()
        {
            //We want to ensure that options set in the serializer are obeyed by our formatter

            //Arrange
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.DateFormatString = "dd-MMM-yyyy";

            jsonSerializer.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            jsonSerializer.Converters.Add(new OptionalConverter());
            var stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(stringWriter);
            var dto = new DateTimeDto
            {
                Value = DateTime.MaxValue
            };

            //Act
            jsonSerializer.Serialize(jsonWriter, dto);


            //Assert
            Assert.Equal(@"{""Value"":""31-Dec-9999""}", stringWriter.ToString());
        }


        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            var dto = new DateTimeDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new DateTimeDto
            {
                Value = DateTime.MaxValue
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":""9999-12-31T23:59:59.9999999""}", sw.ToString());
        }
    }
}