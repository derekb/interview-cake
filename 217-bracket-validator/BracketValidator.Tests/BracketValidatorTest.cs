using NUnit.Framework;
using InterviewCake;

namespace Tests
{
    [TestFixture]
    public class BracketValidatorTest
    {
        [Test]
        public void OpenerWithNoCloserIsNotValid()
        {
            var validator = CreateValidator();
            Assert.IsFalse(validator.IsValid("{"));
        }

        [Test]
        public void CloserWithNoOpenerIsNotValid()
        {
            var validator = CreateValidator();
            Assert.IsFalse(validator.IsValid("}"));
        }

        [Test]
        public void OpenerWithMatchingCloserIsValid()
        {
            var validator = CreateValidator();
            Assert.IsTrue(validator.IsValid("{}"));
        }

        [Test]
        public void OpenerWithNonMatchingCloserIsInvalid()
        {
            var validator = CreateValidator();
            Assert.IsFalse(validator.IsValid("{]"));
        }

        [Test]
        public void OutOfOrderOpenersAndClosersAreInvalid()
        {
            var validator = CreateValidator();
            Assert.IsFalse(validator.IsValid("{[}]"));
        }

        [Test]
        public void NestedMatchedSetsAreValid()
        {
            var validator = CreateValidator();
            Assert.IsTrue(validator.IsValid("{[(){}]()}"));
        }

        private static BracketValidator CreateValidator()
        {
            return new BracketValidator();
        }

    }
}