using System;
using NUnit.Framework;
using static NumbersExtensions.NumbersExtension;

namespace NumbersExtensions.Tests
{
    public class NumbersExtensionTests
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(-7, 2, 31,31, ExpectedResult = 2147483641)]
        public int InsertNumberIntoAnother_WithAllValidParameters(int numberSource, int numberIn, int i, int j) =>
            InsertNumberIntoAnother(numberSource, numberIn, i, j);

        [Test]
        public void InsertNumberIntoAnother_I_GreaterThan_J_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => InsertNumberIntoAnother(123, 12, 13, 8), "i cannot be greater than j.");

        [Test]
        public void InsertNumberIntoAnother_I_Or_J_OutOfRange_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(12, 2, 0, 32));

        [TestCase(123021, ExpectedResult = false)]
        [TestCase(345543, ExpectedResult = true)]
        [TestCase(1615201561, ExpectedResult = false)]
        [TestCase(int.MaxValue, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(33333333, ExpectedResult = true)]
        [TestCase(-123321, ExpectedResult = true)]
        [TestCase(-333345333, ExpectedResult = false)]
        public bool IsPalindromeTests(int number) => IsPalindrome(number);
    }
}