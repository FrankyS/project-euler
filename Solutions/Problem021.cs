namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

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
			ICollection<long> amicableNumbers = GetAmicableNumbers(10000);

			long sum = 0;
			foreach(long amicableNumber in amicableNumbers)
			{
				sum += amicableNumber;
			}

			return sum;
		}

		private static ICollection<long> GetAmicableNumbers(long upperBound)
		{
			ICollection<long> amicableNumbers = new HashSet<long>();

			for (long number = 4; number < upperBound; number++)
			{
				long sumOfDivisors = GetSumOfDivisors(number);
				long otherSum = GetSumOfDivisors(sumOfDivisors);

				if (number != sumOfDivisors && otherSum == number)
				{
					amicableNumbers.Add(number);
					amicableNumbers.Add(sumOfDivisors);
				}
			}

			return amicableNumbers;
		}

		public static long GetSumOfDivisors(long number)
		{
			long sum = 1;
			for (long divisor = 2; divisor <= number / 2; divisor++)
			{
				if (number % divisor == 0)
				{
					sum += divisor;
				}
			}

			return sum;
		}

		[Test]
		public void TestForExample() 
		{
			long[] expectedNumbers = { 220, 284 };

			ICollection<long> amicableNumbers = GetAmicableNumbers(300);

			Assert.AreEqual(expectedNumbers, amicableNumbers);
		}

		[Test]
		public void TestForProblem() 
		{
			Assert.AreEqual(31626, this.Solution());
		}
	}
}