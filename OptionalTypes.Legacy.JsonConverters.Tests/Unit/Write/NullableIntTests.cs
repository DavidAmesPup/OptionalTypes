using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class NullableIntTests
    {
        [Fact]
        public static void CanWriteNullValue()
        {
            //Arrange
            var dto = new NullableIntDto
            {
                Value = null
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":null}", sw.ToString());
        }

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            var dto = new NullableIntDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new NullableIntDto
            {
                Value = 5
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":5}", sw.ToString());
        }
    }
}