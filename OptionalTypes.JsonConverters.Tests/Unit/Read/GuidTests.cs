using System;
using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class EnumTests
    {
        [Fact]
        public static void Convert_GivenGuid_ShouldSetValue()
        {
            //Arrange
            var json = @"{""Value"": ""70B1B6FD-11E8-4334-B157-5E1CD60ADE03""}";

            //Act
            var dto = SerialisationUtils.Deserialize<GuidDto>(json);

            //Assert
            Assert.Equal(dto.Value.Value, new Guid("70B1B6FD-11E8-4334-B157-5E1CD60ADE03"));
        }

        [Fact]
        public static void Convert_GivenNotAValidGuid_ShouldThrowMeaningfulException()
        {
            //Arrange
            var json = @"{""Value"": ""YouWillNotFindMe""}";

            //Act
            Assert.Throws<CannotCreateGuidException>(() => SerialisationUtils.Deserialize<GuidDto>(json));

        }

    }
}