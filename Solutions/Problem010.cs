namespace ProjectEuler.Solutions
{
	using System.Collections;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Summation of primes.
	/// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
	/// <para>Find the sum of all the primes below two million.</para>
	/// </summary>
	public class Problem010 : Problem
	{
		public override long Solution()
		{
			return SumOfPrimes(2000000);
		}

		private static long SumOfPrimes(int upperBound)
		{
			long sum = 0;
			foreach(int primeNumber in EratosthenesSieve(upperBound))
			{
				sum += primeNumber;
			}

			return sum;
		}

		public static List<int> EratosthenesSieve(int upperbound)
		{
			List<int> primes = new List<int>(upperbound);

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
				if (bitArray.Get(i))
				{
					primes.Add(i);
				}
			}

			return primes;
		}

		[Test]
		public void TestForExample()
		{
			long sumOfPrimes = SumOfPrimes(10);

			Assert.AreEqual(17, sumOfPrimes);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(142913828922, this.Solution());
		}
	}
}