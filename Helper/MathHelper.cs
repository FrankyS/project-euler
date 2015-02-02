namespace ProjectEuler.Helper
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;

	public static class MathHelper
	{
		public static IEnumerable<long> GetFibonacci()
		{
			long first = 1;
			yield return first;

			long second = 2;
			yield return second;

			while(true)
			{
				long next = first + second;
				first = second;
				second = next;

				if(next > long.MaxValue)
				{
					yield break;
				}
				yield return next;
			}
		}

		public static IEnumerable<long> GetPrimeFactors(long number)
		{
			foreach(long primeNumber in GetPrimeNumber())
			{
				if(number <= 1)
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
				if(number > long.MaxValue)
				{
					yield break;
				}
				if (IsPrimeNumber(number))
				{
					yield return number;
				}
			}
		}

		public static bool IsPalindrome(long number)
		{
			bool isPalindrome = true;

			string numberString = number.ToString(CultureInfo.InvariantCulture);
			int length = numberString.Length;
			for (int i = 0; i < length / 2; i++)
			{
				if (numberString[i] != numberString[length - 1 - i])
				{
					isPalindrome = false;
					break;
				}
			}

			return isPalindrome;
		}

		public static bool IsPrimeNumber(long number)
		{
			bool isPrime = true;
			for (int i = 3; i <= Math.Sqrt(number); i += 2)
			{
				if (number % i == 0)
				{
					isPrime = false;
				}
			}

			return isPrime;
		}

		public static long SumMultiples(long upperBound, params long[] divisors)
		{
			long sum = 0;
			for(long value = 0; value < upperBound; value++)
			{
				if (divisors.Any(divisor => value % divisor == 0))
				{
					sum += value;
				}
			}

			return sum;
		}
	}
}