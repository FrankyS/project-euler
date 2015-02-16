namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Distinct primes factors.
	/// The first two consecutive numbers to have two distinct prime factors are:
	/// <para>14 = 2 × 7</para>
	/// <para>15 = 3 × 5</para>
	/// The first three consecutive numbers to have three distinct prime factors are:
	/// <para>644 = 2<sup>2</sup> × 7 × 23</para>
	/// <para>645 = 3 × 5 × 43</para>
	/// <para>646 = 2 × 17 × 19.</para>
	/// Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
	/// </summary>
	public class Problem047 : Problem
	{
		private static readonly List<int> primeNumbers = Problem010.EratosthenesSieve(2000000);

		public override long Solution()
		{
			long number;

			for (int i = 1000; ; i++)
			{
				bool foundNumber = true;
				for (int j = 0; j < 4; j++)
				{
					if (GetDistinctPrimeFactorsCount(i + j) != 4)
					{
						foundNumber = false;
						i = i + j;
						break;
					}
				}

				if (foundNumber)
				{
					number = i;
					break;
				}
			}

			return number;
		}

		private static int GetDistinctPrimeFactorsCount(long number)
		{
			int count = 0;
			foreach (int primeNumber in primeNumbers)
			{
				if (primeNumber * primeNumber > number)
				{
					count++;
					break;
				}

				bool isFactor = false;
				while (number % primeNumber == 0)
				{
					number /= primeNumber;
					isFactor = true;
				}

				if (isFactor)
				{
					count++;
				}

				if (number == 1)
				{
					break;
				}
			}

			return count;
		}

		[Test]
		public void TestForExample()
		{
			Assert.AreEqual(3, GetDistinctPrimeFactorsCount(644));
			Assert.AreEqual(3, GetDistinctPrimeFactorsCount(645));
			Assert.AreEqual(3, GetDistinctPrimeFactorsCount(646));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(134043, this.Solution());
		}
	}
}