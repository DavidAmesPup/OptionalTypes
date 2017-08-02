using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class GuidTests
    {
        [Fact]
        public static void Convert_GivenMatchingCaseEnum_ShouldSetValue()
        {
            //Arrange
            var json = @"{""Value"": ""TitleCase""}";

            //Act
            var dto = SerialisationUtils.Deserialize<EnumDto>(json);

            //Assert
            Assert.Equal(dto.Value.Value, SomeEnum.TitleCase);
        }


        [Fact]
        public static void Convert_GivenNotExistentEnum_ShouldThrowMeaningfulException()
        {
            //Arrange
            var json = @"{""Value"": ""YouWillNotFindMe""}";

            //Act
            Assert.Throws<CannotCreateEnumException>(() => SerialisationUtils.Deserialize<EnumDto>(json));
        }

        [Fact]
        public static void Convert_GivenNotingCaseEnum_ShouldSetValue()
        {
            //Arrange
            var json = @"{""Value"": ""TITLECASE""}";

            //Act
            var dto = SerialisationUtils.Deserialize<EnumDto>(json);

            //Assert
            Assert.Equal(dto.Value.Value, SomeEnum.TitleCase);
        }
    }
}