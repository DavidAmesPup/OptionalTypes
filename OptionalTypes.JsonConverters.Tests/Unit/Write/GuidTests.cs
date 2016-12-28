using System;
using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class GuidTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            GuidDto dto = new GuidDto()
            {
                Value = Guid.Empty
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            string expected = @"{""Value"":""" + Guid.Empty + @"""}";
            Assert.Equal(expected, sw.ToString());
        }

       

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            GuidDto dto = new GuidDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
