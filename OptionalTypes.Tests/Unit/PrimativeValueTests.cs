using System;
using Xunit;

namespace OptionalTypes.Tests.Unit
{
    public static class PrimativeValueTests
    {
        [Fact]
        public static void CanEqualHaveSignValueEquality()
        {
            //Arrange
            var subject1 = new Optional<int>(1);
            var subject2 = new Optional<int>(1);

            //Act & Assert
            Assert.True(subject1 == subject2);
        }


        [Fact]
        public static void CanEqualHaveValueEquality()
        {
            //Arrange
            var subject1 = new Optional<int>(1);
            var subject2 = new Optional<int>(1);

            //Act & Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanInitaliseToNoDefinedValue()
        {
            //Act
            var subject = new Optional<int>();

            Assert.False(subject.IsDefined);
        }


        [Fact]
        public static void CanMatchExecuteWhenHasValue()
        {
            //Arrange
            var subject = new Optional<int>();
            subject = 66;

            var matchedValue = 0;
            var notMachedExecuted = false;

            //Act
            subject.Match(x => matchedValue = x, () => notMachedExecuted = true);

            //Assert
            Assert.False(notMachedExecuted);  //ensure the Not Matched method was not called.
            Assert.Equal(66, matchedValue);
        }

        [Fact]
        public static void CanNotMatchExecuteWhenNoValue()
        {
            //Arrange
            var subject = new Optional<int>();
           
            var matchedValue = 0;
            var notMachedExecuted = false;

            //Act
            subject.Match(x => matchedValue = x, () => notMachedExecuted = true);

            //Assert
            Assert.True(notMachedExecuted);
            Assert.Equal(0, matchedValue);
        }


        [Fact]
        public static void CanNotEqualHaveSignValueInequality()
        {
            //Arrange
            var subject1 = new Optional<int>(1);
            var subject2 = new Optional<int>(1);

            //Act & Assert
            Assert.False(subject1 != subject2);
        }

        [Fact]
        public static void CanNotEqualHaveValueInequality()
        {
            //Arrange
            var subject1 = new Optional<int>(1);
            var subject2 = new Optional<int>(2);

            //Act & Assert
            Assert.NotEqual(subject1, subject2);
        }

        [Fact]
        public static void CanSettingValueInlineSetDefined()
        {
            //Act
            Optional<int> subject = 1;

            Assert.True(subject.IsDefined);
            Assert.Equal(1, subject.Value);
        }


        [Fact]
        public static void CanSettingValueSetDefined()
        {
            //Arrange
            var subject = new Optional<int>();

            //Act
            subject = 1;

            //Assert
            Assert.True(subject.IsDefined);
            Assert.Equal(1, subject.Value);
        }

        [Fact]
        public static void CanTwoUndefinedValuesBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int>();

            //Act
            var subject2 = new Optional<int>();

            //Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanTwoUndefinedValuesOfDifferentTypesNotBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int>();

            //Act
            var subject2 = new Optional<DateTime>();

            //Assert
            Assert.False(subject1.Equals(subject2));
        }
    }
}