using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class ListOfDtosTests
    {
        [Fact]
        public static void Convert_GivenListOfDtos_ShouldReturnPopulatedDto()
        {
            //Arrange
            var json = @"{""Values"": [{""Value"":10}, {""Value"":20}]}";

            //Act
            var dto = SerialisationUtils.Deserialize<ListOfDtosDto>(json);

            //Assert

            Assert.NotNull(dto.Values);
            Assert.Equal(2, dto.Values.Value.Count);
            

        }
    }
}
