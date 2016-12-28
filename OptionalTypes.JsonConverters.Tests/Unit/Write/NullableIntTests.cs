using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class NullableIntTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            NullableIntDto dto = new NullableIntDto()
            {
                Value = 5
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":5}", sw.ToString());
        }


        [Fact]
        public static void CanWriteNullValue()
        {
            //Arrange
            NullableIntDto dto = new NullableIntDto()
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
            NullableIntDto dto = new NullableIntDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
