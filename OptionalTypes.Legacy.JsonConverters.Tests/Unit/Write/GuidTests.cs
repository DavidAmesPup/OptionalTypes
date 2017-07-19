using System;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Write
{
    public static class GuidTests
    {
        [Fact]
        public static void CanWriteUndefined()
        {
            //Arrange
            var dto = new GuidDto();

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            Assert.Equal(@"{""Value"":undefined}", sw.ToString());
        }

        [Fact]
        public static void CanWriteValue()
        {
            //Arrange
            var dto = new GuidDto
            {
                Value = Guid.Empty
            };

            //Act
            var sw = SerialisationUtils.SerializeDto(dto);

            //Assert
            var expected = @"{""Value"":""" + Guid.Empty + @"""}";
            Assert.Equal(expected, sw.ToString());
        }
    }
}