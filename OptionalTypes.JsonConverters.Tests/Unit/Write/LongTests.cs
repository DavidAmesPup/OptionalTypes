using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class LongTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            LongDto dto = new LongDto()
            {
                Value = 99999999999999
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":99999999999999}", sw.ToString());
        }


       

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            LongDto dto = new LongDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
