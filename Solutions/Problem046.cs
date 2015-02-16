namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Goldbach's other conjecture.
	/// It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
	/// <para>9 = 7 + 2×1<sup>2</sup></para>
	/// <para>15 = 7 + 2×2<sup>2</sup></para>
	/// <para>21 = 3 + 2×3<sup>2</sup>2</para>
	/// <para>25 = 7 + 2×3<sup>2</sup>2</para>
	/// <para>27 = 19 + 2×2<sup>2</sup>2</para>
	/// <para>33 = 31 + 2×1<sup>2</sup>2</para>
	/// It turns out that the conjecture was false.
	/// <para>What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?</para>
	/// </summary>
	public class Problem046 : Problem
	{
		public override long Solution()
		{
			long number = 0;

			const int upperbound = 200000;
			List<int> primes = Problem010.EratosthenesSieve(upperbound);
			List<int> nonPrimes = ReversedEratosthenesSieve(upperbound);
			foreach (int nonPrime in nonPrimes)
			{
				if (number > 0)
				{
					break;
				}

				if (nonPrime % 2 != 0)
				{
					foreach (int prime in primes)
					{
						if (prime > nonPrime)
						{
							number = nonPrime;
							break;
						}

						if (CanBeComposited(prime, nonPrime))
						{
							break;
						}
					}
				}
			}

			return number;
		}

		private static bool CanBeComposited(int prime, int nonPrime)
		{
			double result = Math.Sqrt((double)(nonPrime - prime) / 2);
			return result.Equals((int)result);
		}

		private static List<int> ReversedEratosthenesSieve(int upperbound)
		{
			List<int> nonPrimes = new List<int>(upperbound);

			BitArray bitArray = new BitArray(upperbound + 1, true);
			for (int i = 2; i * i < upperbound; i++)
			{
				if (bitArray.Get(i))
				{
					for (int j = i * i; j < upperbound; j += i)
					{
						bitArray.Set(j, false);
					}
				}
			}

			for (int i = 2; i < upperbound; i++)
			{
				if (!bitArray.Get(i))
				{
					nonPrimes.Add(i);
				}
			}

			return nonPrimes;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(5777, this.Solution());
		}
	}
}