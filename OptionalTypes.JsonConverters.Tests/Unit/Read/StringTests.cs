using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class StringTests
    {
        [Fact]
        public static void CanReadMissingValue()
        {
            //Arrange
            var json = @"{""NotFoundValue"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

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
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

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
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            var json = @"{""Value"":""The Value""}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal("The Value", dto.Value);
        }
    }
}