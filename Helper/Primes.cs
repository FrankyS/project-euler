namespace ProjectEuler.Helper
{
	using System.Collections;
	using System.Collections.Generic;

	public static class Primes
	{
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

		public static IEnumerable<long> GetPrimeFactors(long number)
		{
			foreach (long primeNumber in GetPrimeNumber())
			{
				if (primeNumber * primeNumber > number)
				{
					yield return number;
					number = 1;
				}

				while (number % primeNumber == 0)
				{
					number /= primeNumber;
					yield return primeNumber;
				}

				if (number == 1)
				{
					yield break;
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
	}
}