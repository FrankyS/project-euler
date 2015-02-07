namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Power digit sum.
	/// 2<sup>15</sup> = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
	/// <para>What is the sum of the digits of the number 2<sup>1000</sup>?</para>
	/// </summary>
	public class Problem016 : Problem
	{
		public override long Solution()
		{
			return GetSumOfPowerTwo(1000);
		}

		private static long GetSumOfPowerTwo(int upperBound)
		{
			List<int> digits = new List<int>
				{
					2
				};

			for (int power = 1; power < upperBound; power++)
			{
				int carry = 0;
				for (int i = 0; i < digits.Count; i++)
				{
					int digit = digits[i] * 2;
					if (digit > 9)
					{
						digits[i] = (digit % 10) + carry;
						carry = 1;
					}
					else
					{
						digits[i] = digit + carry;
						carry = 0;
					}
				}

				if (carry > 0)
				{
					digits.Add(carry);
				}
			}

			long sum = 0;
			foreach(int digit in digits)
			{
				sum += digit;
			}

			return sum;
		}

		[Test]
		public void TestForExample()
		{
			long sum = GetSumOfPowerTwo(15);

			Assert.AreEqual(26, sum);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(1366, this.Solution());
		}
	}
}