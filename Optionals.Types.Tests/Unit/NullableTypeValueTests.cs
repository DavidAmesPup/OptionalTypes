using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Optionals.Types;

using Xunit;

namespace Optionals.Types.Tests.Unit
{
    public static class NullableValueTests
    {
        [Fact]
        public static void CanInitaliseToNoDefinedValue()
        {
            //Act
            var subject = new Optional<int?>();

            Assert.False(subject.IsDefined);
        }


        [Fact]
        public static void CanSettingValueSetDefined()
        {
            //Arrange
            var subject = new Optional<int?>();

            //Act
            subject = 1;

            //Assert
            Assert.True(subject.IsDefined);
            Assert.Equal(1, subject.Value);
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
        public static void CanTwoUndefinedValuesBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>();

            //Act
            var subject2 = new Optional<int?>();

            //Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanTwoUndefinedValuesOfDifferentTypesNotBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>();

            //Act
            var subject2 = new Optional<DateTime?>();

            //Assert
            Assert.False(subject1.Equals(subject2));
        }



        [Fact]
        public static void CanEqualHaveValueEquality()
        {
            //Arrange
            var subject1 = new Optional<int?>(1);
            var subject2 = new Optional<int?>(1);

            //Act & Assert
            Assert.Equal(subject1, subject2);
        }

        [Fact]
        public static void CanNotEqualHaveValueInequality()
        {
            //Arrange
            var subject1 = new Optional<int?>(1);
            var subject2 = new Optional<int?>(2);

            //Act & Assert
            Assert.NotEqual(subject1, subject2);
        }


        [Fact]
        public static void CanEqualHaveSignValueEquality()
        {
            //Arrange
            var subject1 = new Optional<int?>(1);
            var subject2 = new Optional<int?>(1);

            //Act & Assert
            Assert.True(subject1 == subject2);
        }

        [Fact]
        public static void CanNotEqualHaveSignValueInequality()
        {
            //Arrange
            var subject1 = new Optional<int?>(1);
            var subject2 = new Optional<int?>(1);

            //Act & Assert
            Assert.False(subject1 != subject2);
        }
    }
}
