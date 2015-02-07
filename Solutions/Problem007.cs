namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// 10001st prime.
	/// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
	/// <para>What is the 10 001st prime number?</para>
	/// </summary>
	public class Problem007 : Problem
	{
		public override long Solution()
		{
			long result = 0;
			int counter = 0;
			foreach(long primeNumber in Problem003.GetPrimeNumber())
			{
				counter++;
				if(counter == 10001)
				{
					result = primeNumber;
					break;
				}
			}

			return result;
		}

		[Test]
		public void TestForExample()
		{
			byte[] expectedPrimes = new byte[] { 2, 3, 5, 7, 11, 13 };

			List<long> primes = new List<long>();
			foreach (long prime in Problem003.GetPrimeNumber())
			{
				primes.Add(prime);
				if(primes.Count == 6)
				{
					break;
				}
			}

			Assert.AreEqual(expectedPrimes, primes);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(104743, this.Solution());
		}
	}
}