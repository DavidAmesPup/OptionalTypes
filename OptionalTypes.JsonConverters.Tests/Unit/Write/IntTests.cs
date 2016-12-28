using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class IntTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            IntDto dto = new IntDto()
            {
                Value = 5
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":5}", sw.ToString());
        }


       

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            IntDto dto = new IntDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
