using System;
using System.IO;
using Newtonsoft.Json;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class NullableDateTimeTests
    {

        [Fact]
        public static void CanReadValue()
        {
            //We want to ensure that options set in the serializer are obeyed by our formatter

            //Arrange

            string json = @"{""Value"":""2014-12-21T08:00:00.000000Z""}";

            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
            jsonSerializer.Converters.Add(new OptionalConverter());
            StringReader stringReader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(stringReader);
            

            //Act
            NullableDateTimeDto dto = jsonSerializer.Deserialize<NullableDateTimeDto>(jsonReader);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal(DateTime.Parse("21/12/2014 8:00:00 AM"), dto.Value);
        }


        [Fact]
        public static void CanThrowInformativeExceptionWithIncorrectValue()
        {
            //Arrange
            string json = @"{""Value"":"" This is not a datetime ""}";

            NullableDateTimeDto dto;
            //Act
            InvalidCastException ex = Assert.Throws<InvalidCastException>(() =>
                {
                    dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);
                }
            );

        //Assert
          
            Assert.Equal("Cannot convert  This is not a datetime  to a System.Nullable`1[System.DateTime] because of The string was not recognized as a valid DateTime. There is an unknown word starting at index 1.", ex.Message);
        }



        [Fact]
        public static void CanReadNullValue()
        {
            //Arrange
            string json = @"{""Value"":null}";

            //Act
            NullableDateTimeDto dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadUndefinedValue()
        {
            //Arrange
            string json = @"{""Value"":undefined}";

            //Act
            NullableDateTimeDto dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

        [Fact]
        public static void CanReadMissingValue()
        {
            //Arrange
            string json = @"{""NotFoundValue"":undefined}";

            //Act
            NullableDateTimeDto dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

    }
}
