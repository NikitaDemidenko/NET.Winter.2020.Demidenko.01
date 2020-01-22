using System;
using System.Globalization;
using System.Text;

namespace NumbersExtensions
{
    /// <summary>Provides number extensions methods.</summary>
    public static class NumbersExtension
    {
        private const int MinValueOfIndex = 0;
        private const int MaxValueOfIndex = 31;

        /// <summary>Inserts the number into another.</summary>
        /// <param name="numberSource">The source number.</param>
        /// <param name="numberIn">Number to insert.</param>
        /// <param name="rightIndex">Right position.</param>
        /// <param name="leftIndex">Left position.</param>
        /// <returns>Returns new number.</returns>
        /// <exception cref="ArgumentException">Thrown when right index is greater than left index.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when right index or left index are out of range.</exception>
        public static int InsertNumberIntoAnother(int numberSource, int numberIn, int rightIndex, int leftIndex)
        {
            if (rightIndex > leftIndex)
            {
                throw new ArgumentException($"Invalid arguments.");
            }

            if (rightIndex > MaxValueOfIndex || rightIndex < MinValueOfIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(rightIndex), "Invalid value.");
            }

            if (leftIndex > MaxValueOfIndex || leftIndex < MinValueOfIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(leftIndex), "Invalid value.");
            }

            if (rightIndex == MinValueOfIndex && leftIndex == MaxValueOfIndex)
            {
                return numberIn;
            }

            if (leftIndex == MaxValueOfIndex)
            {
                numberSource &= int.MaxValue;
            }

            int numberSourceCopy = numberSource;
            numberSource >>= leftIndex + 1;
            numberSource <<= leftIndex + 1;
            int multiplierForZeroingLeftPart = (int)(Math.Pow(2, rightIndex) - 1);
            numberSourceCopy &= multiplierForZeroingLeftPart;
            numberSource |= numberSourceCopy;
            multiplierForZeroingLeftPart = (int)(Math.Pow(2, leftIndex - rightIndex + 1) - 1);
            numberIn &= multiplierForZeroingLeftPart;
            numberIn <<= rightIndex;
            return numberSource | numberIn;
        }

        /// <summary>Determines whether the specified number is palindrome.</summary>
        /// <param name="number">Number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is palindrome; otherwise, <c>false</c>.</returns>
        public static bool IsPalindrome(int number)
        {
            var numberString = new StringBuilder(Math.Abs(number).ToString(CultureInfo.InvariantCulture));
            int firstDigitIndex = 0;
            int lastDigitIndex = numberString.Length - 1;
            if (numberString[firstDigitIndex] == numberString[lastDigitIndex])
            {
                if (lastDigitIndex <= 1)
                {
                    return true;
                }

                numberString.Remove(lastDigitIndex, 1);
                numberString.Remove(firstDigitIndex, 1);
                return IsPalindrome(int.Parse(numberString.ToString(), CultureInfo.InvariantCulture));
            }

            return false;
        }
    }
}
