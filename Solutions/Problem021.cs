namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Amicable numbers.
	/// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
	/// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
	/// <para>
	/// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
	/// </para>
	/// Evaluate the sum of all the amicable numbers under 10000.
	/// </summary>
	public class Problem021 : Problem
	{
		public override long Solution()
		{
			long[] amicableNumbers = GetAmicableNumbers(10000);
			return amicableNumbers.Sum();
		}

		private static long[] GetAmicableNumbers(long upperBound)
		{
			HashSet<long> amicableNumbers = new HashSet<long>();

			for (long number = 4; number < upperBound; number++)
			{
				long sumOfDivisors = MathHelper.GetDivisors(number, true)
					.Sum();

				long otherSum = MathHelper.GetDivisors(sumOfDivisors, true)
					.Sum();

				if (number != sumOfDivisors && otherSum == number)
				{
					amicableNumbers.Add(number);
					amicableNumbers.Add(sumOfDivisors);
				}
			}

			return amicableNumbers.ToArray();
		}

		[Test]
		public void TestForExample() 
		{
			long[] expectedNumbers = { 220, 284 };

			long[] amicableNumbers = GetAmicableNumbers(300);

			Assert.AreEqual(expectedNumbers, amicableNumbers);
		}

		[Test]
		public void TestForProblem() 
		{
			Assert.AreEqual(31626, this.Solution());
		}
	}
}