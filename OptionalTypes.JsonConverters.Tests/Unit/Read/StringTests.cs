using OptionalTypes.JsonConverters.Tests.TestDtos;
using Xunit;

namespace OptionalTypes.JsonConverters.Tests.Unit.Read
{
    public static class StringTests
    {

        [Fact]
        public static void CanReadNonOptionalApplicationReceived()
        {
            //Arrange
            var json = @"{""SubscriptionUri"": ""www.google.com"",""Criteria"" :{""departmentId"": 2}}";

            //Act
            var dto = SerialisationUtils.Deserialize<NonOptionalApplicationReceivedSubscription>(json);

            //Assert
        
            Assert.NotNull(dto.Criteria);
            Assert.Equal("www.google.com", dto.SubscriptionUri);
            Assert.Equal(2, dto.Criteria.DepartmentId);

        }



        [Fact]
        public static void CanReadApplicationReceivedOne()
        {
            //Arrange
            var json = @"{""SomeString"": ""www.google.com"", ""SubscriptionUri"": ""www.google.com"",""Criteria"" :{""departmentId"": 2}}";

            //Act
            var dto = SerialisationUtils.Deserialize<ApplicationReceivedSubscription>(json);

            //Assert
            Assert.NotNull(dto.Criteria);
            Assert.Equal("www.google.com", dto.SubscriptionUri);
            Assert.Equal(2, dto.Criteria.Value.DepartmentId);

        }




        [Fact]
        public static void CanReadApplicationReceivedTwo()
        {
            //Arrange
            var json = @"{ ""SubscriptionUri"": ""www.google.com"",""Criteria"" :{""departmentId"": 2}}";

            //Act
            var dto = SerialisationUtils.Deserialize<ApplicationReceivedSubscription>(json);

            //Assert
            Assert.NotNull(dto.Criteria);
            Assert.Equal("www.google.com", dto.SubscriptionUri);
            Assert.Equal(2, dto.Criteria.Value.DepartmentId);

        }



        [Fact]
        public static void CanReadApplicationReceivedThree()
        {
            //Arrange
            var json = @"{ ""SubscriptionUri"": ""www.google.com"",""Criteria"" :{}}";

            //Act
            var dto = SerialisationUtils.Deserialize<ApplicationReceivedSubscription>(json);

            //Assert
            Assert.NotNull(dto.Criteria);
            Assert.True(dto.Criteria.IsDefined);
            
            Assert.False(dto.Criteria.Value.DepartmentId.IsDefined);

        }



        [Fact]
        public static void CanReadMissingValue()
        {
            //Arrange
            var json = @"{""NotFoundValue"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadNullValue()
        {
            //Arrange
            var json = @"{""Value"":null}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }


        [Fact]
        public static void CanReadUndefinedValue()
        {
            //Arrange
            var json = @"{""Value"":undefined}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.False(dto.Value.IsDefined);
            Assert.Null(dto.Value.Value);
        }

        [Fact]
        public static void CanReadValue()
        {
            //Arrange
            var json = @"{""Value"":""The Value""}";

            //Act
            var dto = SerialisationUtils.Deserialize<StringDto>(json);

            //Assert
            Assert.True(dto.Value.IsDefined);
            Assert.Equal("The Value", dto.Value);
        }
    }
}