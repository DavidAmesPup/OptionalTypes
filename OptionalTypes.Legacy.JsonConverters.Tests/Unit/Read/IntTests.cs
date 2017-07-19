using System;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class IntTests
    {
        [Fact]
        public static void CanNullValueCauseException()
        {
            //Arrange
            var json = @"{""Value"":null}";

            // ReSharper disable once NotAccessedVariable
            IntDto dto;
            //Act
            var ex = Assert.Throws<InvalidCastException>(() => { dto = SerialisationUtils.Deserialize<IntDto>(json); }
            );

            //Assert

            Assert.Equal("Cannot convert null to a System.Int32 because it does not allow null values.", ex.Message);
        }

        [Fact]
        public static void CanReadMissingValue()
        {
            //Arrange
            var json = @"{""NotFoundValue"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadUndefinedValue()
        {
            //Arrange
            var json = @"{""Value"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            var json = @"{""Value"":42}";

            //Act
            var dto = SerialisationUtils.Deserialize<IntDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal(42, dto.Value);
        }


        [Fact]
        public static void CanThrowInformativeExceptionWithIncorrectValue()
        {
            //Arrange
            var json = @"{""Value"":"" This is not an int ""}";

            // ReSharper disable once NotAccessedVariable
            IntDto dto;
            //Act
            var ex = Assert.Throws<InvalidCastException>(() => { dto = SerialisationUtils.Deserialize<IntDto>(json); }
            );

            //Assert

            Assert.Equal("Cannot convert  This is not an int  to a System.Int32 because of Input string was not in a correct format.", ex.Message);
        }
    }
}