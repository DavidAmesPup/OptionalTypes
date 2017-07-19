using System;
using Xunit;

namespace OptionalTypes.Tests.Unit
{
    public static class NullableValueTests
    {
        [Fact]
        public static void VariousEquality_GivenEqualOptionals_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>(5);
            var subject2 = new Optional<int?>(5);

            //Act & Assert
            Assert.True(subject1 == subject2);
            Assert.False(subject1 != subject2);
            Assert.Equal(subject1, subject2);
            Assert.True(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousEquality_GivenEqualOptionalAndUnderlyingInt_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>(5);
            var subject2 = 5;

            //Act & Assert
            Assert.True(subject1 == subject2);
            Assert.False(subject1 != subject2);
            Assert.Equal(subject1, subject2);
            Assert.True(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousEquality_GivenEqualUnderlyingIntAndOptional_ShouldBeEqual()
        {
            //Arrange
            var subject1 = 5;
            var subject2 = new Optional<int?>(5);

            //Act & Assert
            Assert.False(subject1 != subject2);
            Assert.True(subject1 == subject2);
            Assert.Equal(subject1, subject2);
            //    Assert.True(subject1.Equals(subject2)); TODO: fix.  
        }


        [Fact]
        public static void VariousInequality_GivenNotEqualOptionals_ShouldBeNotEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>(5);
            var subject2 = new Optional<int?>(10);

            //Act & Assert
            Assert.False(subject1 == subject2);
            Assert.True(subject1 != subject2);
            Assert.NotEqual(subject1, subject2);
            Assert.False(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousInequality_GivenNotEqualOptionalAndUnderlyingInt_ShouldBeNotEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>(10);
            var subject2 = 5;

            //Act & Assert
            Assert.False(subject1 == subject2);
            Assert.True(subject1 != subject2);
            Assert.NotEqual(subject1, subject2);
            Assert.False(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousInequality_GivenNotEqualUnderlyingIntAndOptional_ShouldBeNotEqual()
        {
            //Arrange
            var subject1 = 5;
            var subject2 = new Optional<int?>(10);

            //Act & Assert
            Assert.False(subject1 == subject2);
            Assert.True(subject1 != subject2);
            Assert.NotEqual(subject1, subject2);
            //    Assert.True(subject1.Equals(subject2)); TODO: fix.  
        }



        [Fact]
        public static void Ctor_GivenNoArguments_ShouldBeUndefined()
        {
            //Act
            var subject = new Optional<int?>();

            //Assert
            Assert.False(subject.IsDefined);
        }


        [Fact]
        public static void ImplicitOperatorOnCreation_SettingValue_ShouldDefineValue()
        {
            //Act
            Optional<int?> subject = 5;

            Assert.True(subject.IsDefined);
            Assert.Equal(5, subject.Value);
        }


        [Fact]
        public static void ImplicitOperator_SettingValue_ShouldDefineValue()
        {
            //Arrange
            var subject = new Optional<int?>();

            //Act
            subject = 5;

            //Assert
            Assert.True(subject.IsDefined);
            Assert.Equal(5, subject.Value);

        }

        [Fact]
        public static void VariousEquality_GivenUndefinedOptionals_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>();
            var subject2 = new Optional<int?>();

            //Act & Assert
            Assert.True(subject1 == subject2);
            Assert.False(subject1 != subject2);
            Assert.Equal(subject1, subject2);
            Assert.True(subject1.Equals(subject2));
        }



        [Fact]
        public static void VariousEquality_GivenUndefinedOptionalsOfDiffernetTypes_ShouldNotBeEqual()
        {
            //Arrange
            var subject1 = new Optional<int?>();
            var subject2 = new Optional<DateTime>();

            //Act & Assert 
            Assert.False(subject1.Equals(subject2));
            Assert.False(subject2.Equals(subject1));
        }


        [Fact]
        public static void VariousEquality_GivenNullOptional_ShouldBeEqualToNull()
        {
            //Arrange
            var subject1 = new Optional<int?>(null);

            //Act & Assert
            Assert.True(subject1 == null);
            Assert.False(subject1 != null);
            Assert.Equal(subject1, null);
            Assert.True(subject1.Equals(null));
        }

    }
}