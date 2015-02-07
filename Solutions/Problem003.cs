namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Largest prime factor.
	/// The prime factors of 13195 are 5, 7, 13 and 29.
	/// <para>What is the largest prime factor of the number 600851475143?</para>
	/// </summary>
	public class Problem003 : Problem
	{
		public override long Solution()
		{
			IEnumerator<long> primeFactor = GetPrimeFactors(600851475143)
				.GetEnumerator();
			while(primeFactor.MoveNext()) { }

			return primeFactor.Current;
		}

		public static IEnumerable<long> GetPrimeFactors(long number)
		{
			foreach (long primeNumber in GetPrimeNumber())
			{
				if (number <= 1)
				{
					yield break;
				}

				while (number % primeNumber == 0)
				{
					number /= primeNumber;
					yield return primeNumber;
				}
			}
		}

		public static IEnumerable<long> GetPrimeNumber()
		{
			yield return 2;
			for (long number = 3;; number += 2)
			{
				if (number < 0)
				{
					yield break;
				}

				if (IsPrimeNumber(number))
				{
					yield return number;
				}
			}
		}

		public static bool IsPrimeNumber(long number)
		{
			bool isPrime = number > 1;
			if (number > 3)
			{
				if (number % 2 == 0 || number % 3 == 0)
				{
					isPrime = false;
				}
				else
				{
					for (long i = 5; i * i <= number; i += 6)
					{
						if (number % i == 0 || number % (i + 2) == 0)
						{
							isPrime = false;
							break;
						}
					}
				}
			}

			return isPrime;
		}

		[Test]
		public void TestForExample()
		{
			byte[] expectedFactors = new byte[] { 5, 7, 13, 29 };

			IEnumerable<long> primeFactors = GetPrimeFactors(13195);

			Assert.AreEqual(expectedFactors, primeFactors);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(6857, this.Solution());
		}
	}
}