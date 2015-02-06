namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;

	/// <summary>
	/// Digit fifth powers.
	/// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
	/// <para>1634 = 1<sup>4</sup> + 6<sup>4</sup> + 3<sup>4</sup> + 4<sup>4</sup></para>
	/// <para>8208 = 8<sup>4</sup> + 2<sup>4</sup> + 0<sup>4</sup> + 8<sup>4</sup></para>
	/// <para>9474 = 9<sup>4</sup> + 4<sup>4</sup> + 7<sup>4</sup> + 4<sup>4</sup></para>
	/// As 1 = 1<sup>4</sup> is not a sum it is not included.
	/// <para>The sum of these numbers is 1634 + 8208 + 9474 = 19316.</para>
	/// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
	/// </summary>
	public class Problem030 : Problem
	{
		public override long Solution()
		{
			long totalSum = 0;
			for(int i = 2; i < 354295; i++)
			{
				int sum = SumOfDigitsNthPower(i, 5);
				if(sum == i)
				{
					totalSum += sum;
				}
			}

			return totalSum;
		}

		private static int SumOfDigitsNthPower(int number, int power)
		{
			int sum = 0;
			while(number > 0)
			{
				int digit = number % 10;
				number /= 10;

				sum += (int)Math.Pow(digit, power);
			}

			return sum;
		}

		[TestCase(1634)]
		[TestCase(8208)]
		[TestCase(9474)]
		public void TestForExample(int number)
		{
			Assert.AreEqual(number, SumOfDigitsNthPower(number, 4));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(443839, this.Solution());
		}
	}
}