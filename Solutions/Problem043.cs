namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Sub-string divisibility.
	/// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
	/// <para>Let d<sub>1</sub> be the 1st digit, d<sub>2</sub> be the 2nd digit, and so on. In this way, we note the following:</para>
	/// <para>d<sub>2</sub>d<sub>3</sub>d<sub>4</sub>=406 is divisible by 2</para>
	/// <para>d<sub>3</sub>d<sub>4</sub>d<sub>5</sub>=063 is divisible by 3</para>
	/// <para>d<sub>4</sub>d<sub>5</sub>d<sub>6</sub>=635 is divisible by 5</para>
	/// <para>d<sub>5</sub>d<sub>6</sub>d<sub>7</sub>=357 is divisible by 7</para>
	/// <para>d<sub>6</sub>d<sub>7</sub>d<sub>8</sub>=572 is divisible by 11</para>
	/// <para>d<sub>7</sub>d<sub>8</sub>d<sub>9</sub>=728 is divisible by 13</para>
	/// <para>d<sub>8</sub>d<sub>9</sub>d<sub>10</sub>=289 is divisible by 17</para>
	/// Find the sum of all 0 to 9 pandigital numbers with this property.
	/// </summary>
	public class Problem043 : Problem
	{
		private static readonly int[] divisors = new int[] { 17, 13, 11, 7, 5, 3, 2 };

		public override long Solution()
		{
			long sum = 0;

			List<string> pandigitalNumbers = new List<string>();
			char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			for (int i = 17; i < 1000; i += 17)
			{
				string number = i.ToString().PadLeft(3, '0');
				if (number[0] != number[1] && number[1] != number[2] && number[0] != number[2])
				{
					char[] remainingDigits = RemoveUsedDigits(digits, number.ToCharArray());
					AdvancePandigitalNumber(remainingDigits, pandigitalNumbers, number, 1);
				}
			}

			foreach (string pandigitalNumber in pandigitalNumbers)
			{
				sum += long.Parse(pandigitalNumber);
			}
			
			return sum;
		}

		private static void AdvancePandigitalNumber(char[] digits, List<string> pandigitalNumbers, string numberString, int divisorIndex)
		{
			string firstTwoDigits = numberString.Substring(0, 2);
			if (divisorIndex < 7)
			{
				foreach (char digit in digits)
				{
					string newNumberString = digit + firstTwoDigits;
					long newNumber = long.Parse(newNumberString);
					if (newNumber % divisors[divisorIndex] == 0)
					{
						char[] remainingDigits = RemoveUsedDigits(digits, digit);
						AdvancePandigitalNumber(remainingDigits, pandigitalNumbers, digit + numberString, divisorIndex + 1);
					}
				}
			}
			else
			{
				string pandigitalNumber = digits[0] + numberString;
				pandigitalNumbers.Add(pandigitalNumber);
			}
		}

		private static char[] RemoveUsedDigits(IEnumerable<char> digits, params char[] usedDigits)
		{
			List<char> remainingDigits = new List<char>(digits);
			foreach (char usedDigit in usedDigits)
			{
				remainingDigits.Remove(usedDigit);
			}

			return remainingDigits.ToArray();
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(16695334890, this.Solution());
		}
	}
}