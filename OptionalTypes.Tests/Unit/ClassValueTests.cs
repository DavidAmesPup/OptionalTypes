using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Optionals.Types;

using Xunit;

namespace OptionalTypes.Tests.Unit
{
    public static class ClassValueTests
    {
        [Fact]
        public static void CanInitaliseToNoDefinedValue()
        {
            //Act
            var subject = new Optional<string>();

            Assert.False(subject.IsDefined);
        }


        [Fact]
        public static void CanSettingValueSetDefined()
        {
            //Arrange
            var subject = new Optional<string>();

            //Act
            subject = "Test";

            //Assert
            Assert.True(subject.IsDefined);
            Assert.Equal("Test", subject.Value);
        }

        [Fact]
        public static void CanSettingValueInlineSetDefined()
        {
            //Act
            Optional<string> subject = "Test";

            Assert.True(subject.IsDefined);
            Assert.Equal("Test", subject.Value);
        }

        [Fact]
        public static void CanTwoUndefinedValuesBeEqual()
        {
            //Arrange
            var subject1 = new Optional<string>();

            //Act
            var subject2 = new Optional<string>();

            //Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanTwoUndefinedValuesOfDifferentTypesNotBeEqual()
        {
            //Arrange
            var subject1 = new Optional<string>();

            //Act
            var subject2 = new Optional<DateTime>();

            //Assert
            Assert.False(subject1.Equals(subject2));
        }



        [Fact]
        public static void CanEqualHaveValueEquality()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("Test");

            //Act & Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanNotEqualHaveValueInequality()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("Test_1");

            //Act & Assert
            Assert.NotEqual(subject1, subject2);
        }


        [Fact]
        public static void CanEqualHaveSignValueEquality()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("Test");

            //Act & Assert
            Assert.True(subject1 == subject2);
        }

        [Fact]
        public static void CanNotEqualHaveSignValueInequality()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("Test");

            //Act & Assert
            Assert.False(subject1 != subject2);
        }
    }
}
