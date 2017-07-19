using System;
using Xunit;

namespace OptionalTypes.Tests.Unit
{
    public static class ClassValueTests
    {
        [Fact]
        public static void VariousEquality_GivenEqualOptionals_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("Test");

            //Act & Assert
            Assert.True(subject1 == subject2);
            Assert.False(subject1 != subject2);
            Assert.Equal(subject1,subject2);
            Assert.True(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousEquality_GivenEqualOptionalAndUnderlyingString_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<string>("Test");
            var subject2 = "Test";

            //Act & Assert
            Assert.True(subject1 == subject2);
            Assert.False(subject1 != subject2);
            Assert.Equal(subject1, subject2);
            Assert.True(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousEquality_GivenEqualUnderlyingStringAndOptional_ShouldBeEqual()
        {
            //Arrange
            var subject1 = "Test";
            var subject2 = new Optional<string>("Test");
      
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
            var subject1 = new Optional<string>("Test");
            var subject2 = new Optional<string>("NotTest");

            //Act & Assert
            Assert.False(subject1 == subject2);
            Assert.True(subject1 != subject2);
            Assert.NotEqual(subject1, subject2);
            Assert.False(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousInequality_GivenNotEqualOptionalAndUnderlyingString_ShouldBeNotEqual()
        {
            //Arrange
            var subject1 = new Optional<string>("NotTest");
            var subject2 = "Test";

            //Act & Assert
            Assert.False(subject1 == subject2);
            Assert.True(subject1 != subject2);
            Assert.NotEqual(subject1, subject2);
            Assert.False(subject1.Equals(subject2));
        }


        [Fact]
        public static void VariousInequality_GivenNotEqualUnderlyingStringAndOptional_ShouldBeNotEqual()
        {
            //Arrange
            var subject1 = "Test";
            var subject2 = new Optional<string>("NotTest");

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
            var subject = new Optional<string>();

            //Assert
            Assert.False(subject.IsDefined);
        }

        
        [Fact]
        public static void ImplicitOperatorOnCreation_SettingValue_ShouldDefineValue()
        {
            //Act
            Optional<string> subject = "Test";

            Assert.True(subject.IsDefined);
            Assert.Equal("Test", subject.Value);
        }


        [Fact]
        public static void ImplicitOperator_SettingValue_ShouldDefineValue()
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
        public static void VariousEquality_GivenUndefinedOptionals_ShouldBeEqual()
        {
            //Arrange
            var subject1 = new Optional<string>();
            var subject2 = new Optional<string>();

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
            var subject1 = new Optional<string>();
            var subject2 = new Optional<DateTime>();

            //Act & Assert 
            Assert.False(subject1.Equals(subject2));
            Assert.False(subject2.Equals(subject1));
        }
        

        [Fact]
        public static void VariousEquality_GivenNullOptional_ShouldBeEqualToNull()
        {
            //Arrange
            var subject1 = new Optional<string>(null);
           
            //Act & Assert
            Assert.True(subject1 == null);
            Assert.False(subject1 != null);
            Assert.Equal(subject1, null);
            Assert.True(subject1.Equals(null));
        }
        
    }
}