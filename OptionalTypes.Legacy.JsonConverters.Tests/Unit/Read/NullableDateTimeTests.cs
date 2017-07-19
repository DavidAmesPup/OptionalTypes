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
        public static void CanReadMissingValue()
        {
            //Arrange
            var json = @"{""NotFoundValue"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadNullValue()
        {
            //Arrange
            var json = @"{""Value"":null}";

            //Act
            var dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadUndefinedValue()
        {
            //Arrange
            var json = @"{""Value"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

        [Fact]
        public static void CanReadValue()
        {
            //We want to ensure that options set in the serializer are obeyed by our formatter

            //Arrange

            var json = @"{""Value"":""2014-01-01T08:00:00.000000Z""}";

            var jsonSerializer = new JsonSerializer();
            jsonSerializer.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
            jsonSerializer.Converters.Add(new OptionalConverter());
            var stringReader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(stringReader);


            //Act
            var dto = jsonSerializer.Deserialize<NullableDateTimeDto>(jsonReader);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal(DateTime.Parse("01/01/2014 8:00:00 AM"), dto.Value);
        }


        [Fact]
        public static void CanThrowInformativeExceptionWithIncorrectValue()
        {
            //Arrange
            var json = @"{""Value"":"" This is not a datetime ""}";

            // ReSharper disable once NotAccessedVariable
            NullableDateTimeDto dto;
            //Act
            var ex = Assert.Throws<InvalidCastException>(() => { dto = SerialisationUtils.Deserialize<NullableDateTimeDto>(json); }
            );

            //Assert

            Assert.Equal(
                "Cannot convert  This is not a datetime  to a System.Nullable`1[System.DateTime] because of The string was not recognized as a valid DateTime. There is an unknown word starting at index 1.",
                ex.Message);
        }
    }
}