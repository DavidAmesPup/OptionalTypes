using System;
using System.IO;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class DateTimeTests
    {

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            DateTimeDto dto = new DateTimeDto()
            {
                Value = DateTime.MaxValue
            };

            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":""9999-12-31T23:59:59.9999999""}", sw.ToString());
        }


       

        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            DateTimeDto dto = new DateTimeDto();
           
            //Act
            StringWriter sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal( @"{""Value"":undefined}", sw.ToString());
        }

    }
}
