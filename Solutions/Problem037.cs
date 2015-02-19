namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Truncatable primes.
	/// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. 
	/// Similarly we can work from right to left: 3797, 379, 37, and 3.
	/// <para>Find the sum of the only eleven primes that are both truncatable from left to right and right to left.</para>
	/// <b>NOTE</b>: 2, 3, 5, and 7 are not considered to be truncatable primes.
	/// </summary>
	public class Problem037 : Problem
	{
		public override long Solution()
		{
			List<long> truncatablePrimes = new List<long>();
			foreach(long prime in Primes.GetPrimeNumber())
			{
				if(IsTruncatablePrime(prime))
				{
					truncatablePrimes.Add(prime);
				}

				if(truncatablePrimes.Count == 11)
				{
					break;
				}
			}

			long sum = 0;
			foreach(long truncatablePrime in truncatablePrimes)
			{
				sum += truncatablePrime;
			}

			return sum;
		}

		private static bool IsTruncatablePrime(long prime)
		{
			long leftPrime = prime;
			long rightPrime = prime;

			string primeString = prime.ToString();
			int length = primeString.Length;

			bool isTruncatable = length > 1;

			int upperFactor = (int)Math.Pow(10, length - 1);
			while(upperFactor > 1)
			{
				leftPrime %= upperFactor;
				rightPrime /= 10;
				if(!Primes.IsPrimeNumber(leftPrime) || !Primes.IsPrimeNumber(rightPrime))
				{
					isTruncatable = false;
					break;
				}

				upperFactor /= 10;
			}

			return isTruncatable;
		}

		[Test]
		public void TestForExample()
		{
			Assert.IsTrue(IsTruncatablePrime(3797));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(748317, this.Solution());
		}
	}
}