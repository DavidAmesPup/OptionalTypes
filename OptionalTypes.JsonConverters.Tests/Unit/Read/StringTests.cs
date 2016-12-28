using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class StringTests
    {

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            string json = @"{""Value"":""The Value""}";
            
            //Act
            StringDto dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal("The Value", dto.Value);
        }


        [Fact]
        public static void CanReadNullValue()
        {
            //Arrange
            string json = @"{""Value"":null}";

            //Act
            StringDto dto = SerialisationUtils.Deserialize<StringDto>(json);

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
            StringDto dto = SerialisationUtils.Deserialize<StringDto>(json);

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
            StringDto dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

    }
}
