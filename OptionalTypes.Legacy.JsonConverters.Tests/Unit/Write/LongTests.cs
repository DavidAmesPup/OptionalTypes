using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class LongTests
    {
        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            var dto = new LongDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new LongDto
            {
                Value = 99999999999999
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":99999999999999}", sw.ToString());
        }
    }
}