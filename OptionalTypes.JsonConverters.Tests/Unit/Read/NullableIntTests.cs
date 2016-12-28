using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class NullableIntTests
    {

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            string json = @"{""Value"":42}";

            //Act
            NullableIntDto dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal(42, dto.Value);
        }


        [Fact]
        public static void CanReadNullValue()
        {
            //Arrange
            string json = @"{""Value"":null}";

            //Act
            NullableIntDto dto = SerialisationUtils.Deserialize<NullableIntDto>(json);

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
