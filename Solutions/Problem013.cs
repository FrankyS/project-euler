namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Input;

	/// <summary>
	/// Large sum.
	/// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
	/// </summary>
	/// <remarks>The digits are stored in the file <a href="Problem013.txt">Problem013.txt</a>.</remarks>
	public class Problem013 : Problem
	{
		public override long Solution()
		{
			string[] rows = Input.Problem013.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			byte[][] numbers = new byte[rows.Length][];
			for(int i = 0; i < rows.Length; i++)
			{
				numbers[i] = Problem008.ToDigitsArray(rows[i]);
			}

			byte[] result = Sum(numbers);
			string stringResult = string.Empty;
			for(int i = 0; i < 10; i++)
			{
				stringResult += result[i];
			}

			return long.Parse(stringResult);
		}

		public static byte[] Sum(params byte[][] numbers)
		{
			int carry = 0;
			List<byte> sumsPerDigit = new List<byte>();

			int amountNumbers = numbers.Length;

			for (int digit = 1;; digit++)
			{
				bool foundDigits = false;
				int sum = carry;
				for (byte number = 0; number < amountNumbers; number++)
				{
					byte[] digits = numbers[number];
					int digitIndex = digits.Length - digit;
					if (digitIndex >= 0)
					{
						foundDigits = true;
						sum += digits[digitIndex];
					}
				}

				if (!foundDigits)
				{
					break;
				}

				sumsPerDigit.Insert(0, (byte)(sum % 10));
				carry = sum / 10;
			}

			while (carry > 0)
			{
				sumsPerDigit.Insert(0, (byte)(carry % 10));
				carry /= 10;
			}

			return sumsPerDigit.ToArray();
		}

		[TestCase("11", "22", "33")]
		[TestCase("4", "21", "25")]
		[TestCase("14", "2", "16")]
		public void TestForSum(string first, string second, string expectedResult)
		{
			byte[] result = Sum(Problem008.ToDigitsArray(first), Problem008.ToDigitsArray(second));

			Assert.AreEqual(expectedResult, string.Join(string.Empty, result));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(5537376230, this.Solution());
		}
	}
}