using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class StringTests
    {
        [Fact]
        public static void CanWriteNullValue()
        {
            //Arrange
            var dto = new StringDto
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
            var dto = new StringDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new StringDto
            {
                Value = "The Value"
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":""The Value""}", sw.ToString());
        }
    }
}