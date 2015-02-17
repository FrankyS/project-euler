namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Consecutive prime sum.
	/// The prime 41, can be written as the sum of six consecutive primes:
	/// <para>41 = 2 + 3 + 5 + 7 + 11 + 13</para>
	/// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
	/// <para>The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.</para>
	/// Which prime, below one-million, can be written as the sum of the most consecutive primes?
	/// </summary>
	public class Problem050 : Problem
	{
		public override long Solution()
		{
			int result = 0;

			int longestCount = 0;
			List<int> primes = Problem010.EratosthenesSieve(1000000);
			foreach (int prime in primes)
			{
				int count = CountOfSumOfPrimes(prime, primes);
				if (count > longestCount)
				{
					longestCount = count;
					result = prime;
				}
			}

			return result;
		}

		private static int CountOfSumOfPrimes(int prime, List<int> primes)
		{
			int count = 0;
			foreach (int primeForSum in primes)
			{
				prime -= primeForSum;
				count++;

				if (prime <= 0)
				{
					int index = 0;
					while (prime < 0)
					{
						prime += primes[index];
						index++;
						count--;
					}

					if (prime != 0)
					{
						count = 0;
					}
					break;
				}
			}
			return count;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(997651, this.Solution());
		}
	}
}