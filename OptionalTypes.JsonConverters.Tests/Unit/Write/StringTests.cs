using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class StringTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            StringDto dto = new StringDto()
            {
                Value = "The Value"
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":""The Value""}", sw.ToString());
        }


        [Fact]
        public static void CanWriteNullValue()
        {
            //Arrange
            StringDto dto = new StringDto()
            {
                Value = null
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":null}", sw.ToString());
        }

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            StringDto dto = new StringDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
