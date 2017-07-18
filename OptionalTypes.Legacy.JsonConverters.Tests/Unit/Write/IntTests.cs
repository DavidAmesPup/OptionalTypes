using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class IntTests
    {
        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            var dto = new IntDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new IntDto
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