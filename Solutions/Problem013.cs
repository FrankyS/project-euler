namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;
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
			int[][] numbers = Input.Problem013.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.ToDigitsArray())
				.ToArray();

			int carry = 0;
			List<int> sumsPerDigit = new List<int>();

			const int amountNumbers = 100;
			const int amountDigits = 50;
			for (int digit = amountDigits - 1; digit >= 0; digit--)
			{
				int sum = carry;
				for (int number = 0; number < amountNumbers; number++)
				{
					sum += numbers[number][digit];
				}

				sumsPerDigit.Insert(0, sum % 10);
				carry = sum / 10;
			}

			string result = carry.ToString(CultureInfo.InvariantCulture);
			result += string.Join(string.Empty, sumsPerDigit.Take(10 - result.Length));
			
			return long.Parse(result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(5537376230, this.Solution());
		}
	}
}