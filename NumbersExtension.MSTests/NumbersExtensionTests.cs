using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NumbersExtensions.NumbersExtension;

namespace NumbersExtension.MSTests
{
    [TestClass]
    public class NumbersExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberIntoAnother_RightIndexGreaterThanLeftIndex_ThrowArgumentException() =>
            InsertNumberIntoAnother(12, 2, 12, 5);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberIntoAnother_IndexesAreOutOfRange_ThrowArgumentOutOfRangeException() =>
            InsertNumberIntoAnother(24, 15, 2, 33);

        [TestMethod]
        public void InsertNumberIntoAnother_WithAllValidParameters_Returned120()
        {
            int numberSource = 8;
            int numberIn = 15;
            int rightIndex = 3;
            int leftIndex = 8;
            int expected = 120;

            int actual = InsertNumberIntoAnother(numberSource, numberIn, rightIndex, leftIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_WithAllValidParameters_Returned2680()
        {
            int numberSource = 2728;
            int numberIn = 655;
            int rightIndex = 3;
            int leftIndex = 8;
            int expected = 2680;

            int actual = InsertNumberIntoAnother(numberSource, numberIn, rightIndex, leftIndex);

            Assert.AreEqual(expected, actual);
        }
    }
}
