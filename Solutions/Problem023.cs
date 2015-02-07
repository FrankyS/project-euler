namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Non-abundant sums.
	/// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
	/// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
	/// <para>
	/// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
	/// </para>
	/// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
	/// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
	/// However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
	/// <para>Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.</para>
	/// </summary>
	public class Problem023 : Problem
	{
		public override long Solution()
		{
			List<long> unexpressableNumbers = new List<long>();

			HashSet<long> abundantNumbers = new HashSet<long>();
			for (long number = 1; number < 28123; number++)
			{
				if (IsAbundant(number))
				{
					abundantNumbers.Add(number);
				}

				if (!CanBeExpressedByAbundant(number, abundantNumbers))
				{
					unexpressableNumbers.Add(number);
				}
			}

			long sum = 0;
			foreach(long unexpressableNumber in unexpressableNumbers)
			{
				sum += unexpressableNumber;
			}

			return sum;
		}

		private static bool CanBeExpressedByAbundant(long number, HashSet<long> abundantNumbers)
		{
			bool canBeExpressed = false;
			foreach (long abundantNumber in abundantNumbers)
			{
				long targetNumber = number - abundantNumber;
				if (abundantNumbers.Contains(targetNumber))
				{
					canBeExpressed = true;
					break;
				}
			}

			return canBeExpressed;
		}

		private static bool IsAbundant(long number)
		{
			long sumOfDivisors = Problem021.GetSumOfDivisors(number);
			return sumOfDivisors > number;
		}

		[Test]
		public void ThatTwelveIsAbundant()
		{
			Assert.IsTrue(IsAbundant(12));
		}

		[Test]
		public void TestForProblem() 
		{
			Assert.AreEqual(4179871, this.Solution());
		}
	}
}