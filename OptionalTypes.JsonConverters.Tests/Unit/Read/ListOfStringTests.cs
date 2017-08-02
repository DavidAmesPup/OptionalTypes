using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class ListOfStringTests
    {
        [Fact]
        public static void Convert_GivenListOfStrings_ShouldReturnPopulatedDto()
        {
            //Arrange
            var json = @"{""Values"": [""firstString"", ""secondString""]}";

            //Act
            var dto = SerialisationUtils.Deserialize<ListOfStringDto>(json);

            //Assert

            Assert.NotNull(dto.Values);
            Assert.Equal(2, dto.Values.Value.Count);
            Assert.True(dto.Values.IsDefined);
        }
    }
}