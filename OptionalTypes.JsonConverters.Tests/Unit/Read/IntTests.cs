using System;
using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class IntTests
    {

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            string json = @"{""Value"":42}";

            //Act
            IntDto dto = SerialisationUtils.Deserialize<IntDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal(42, dto.Value);
        }


        [Fact]
        public static void CanThrowInformativeExceptionWithIncorrectValue()
        {
            //Arrange
            string json = @"{""Value"":"" This is not an int ""}";

            IntDto dto;
            //Act
            InvalidCastException ex = Assert.Throws<InvalidCastException>(() =>
                {
                    dto = SerialisationUtils.Deserialize<IntDto>(json);
                }
            );

        //Assert
           
            Assert.Equal("Cannot convert  This is not an int  to a System.Int32 because of Input string was not in a correct format.", ex.Message);
        }



        [Fact]
        public static void CanNullValueCauseException()
        {
            //Arrange
            string json = @"{""Value"":null}";

            IntDto dto;
            //Act
            InvalidCastException ex = Assert.Throws<InvalidCastException>(() =>
            {
                dto = SerialisationUtils.Deserialize<IntDto>(json);
            }
            );

            //Assert

            Assert.Equal("Cannot convert null to a System.Int32 because it does not allow null values.", ex.Message);

        }


        [Fact]
        public static void CanReadUndefinedValue()
        {
            //Arrange
            string json = @"{""Value"":undefined}";

            //Act
            NullableIntDto dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

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
            NullableIntDto dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

    }
}
