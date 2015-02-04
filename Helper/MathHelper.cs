namespace ProjectEuler.Helper
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;

	public static class MathHelper
	{
		public static int[] Factorial(int number)
		{
			int[] factorial = { 1 };
			for (int i = 1; i <= number; i++)
			{
				factorial = Multiply(factorial, i.ToDigitsArray());
			}

			return factorial;
		}

		public static IEnumerable<long> GetDivisors(long number, bool excludeNumber = false)
		{
			yield return 1;
			for (long divisor = 2; divisor <= number / 2; divisor++)
			{
				if (number % divisor == 0)
				{
					yield return divisor;
				}
			}

			if (!excludeNumber)
			{
				yield return number;
			}
		}

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

				if(next < 0)
				{
					yield break;
				}

				yield return next;
			}
		}



		public static IEnumerable<int[]> GetFibonacciAsArray()
		{
			int[] first = new int[] { 1 };
			yield return first;

			int[] second = new int[] { 2 };
			yield return second;

			while (true)
			{
				int[] next = Sum(first, second);
				first = second;
				second = next;

				if (next.Length > int.MaxValue)
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
				if(number < 0)
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

		public static int[] Multiply(int[] first, int[] second)
		{
			int count = first.Length + second.Length;
			int[] result = new int[0];
			for (int f = first.Length - 1; f >= 0; f--)
			{
				for (int s = second.Length - 1; s >= 0; s--)
				{
					int[] tmpResult = Enumerable.Repeat(0, count).ToArray();
					int targetIndex = (f + s) + 1;
					int value = first[f] * second[s];
					tmpResult[targetIndex] = value % 10;
					while ((value /= 10) > 0)
					{
						targetIndex--;
						tmpResult[targetIndex] = value % 10;
					}

					result = Sum(result, tmpResult);
				}
			}

			return result.SkipWhile(x => x == 0).ToArray();
		}

		public static int[] Sum(params int[][] numbers)
		{
			int carry = 0;
			List<int> sumsPerDigit = new List<int>();

			int amountNumbers = numbers.Length;

			for (int digit = 1; ; digit++)
			{
				bool foundDigits = false;
				int sum = carry;
				for (int number = 0; number < amountNumbers; number++)
				{
					int[] digits = numbers[number];
					int digitIndex = digits.Length - digit;
					if (digitIndex >= 0)
					{
						foundDigits = true;
						sum += digits[digitIndex];
					}
				}

				if (!foundDigits)
				{
					break;
				}

				sumsPerDigit.Insert(0, sum % 10);
				carry = sum / 10;
			}

			while (carry > 0)
			{
				sumsPerDigit.Insert(0, carry % 10);
				carry /= 10;
			}

			return sumsPerDigit.ToArray();
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

		private static bool IsPrimeNumber(long number)
		{
			bool isPrime = number > 1;
			if(number > 3)
			{
				if(number % 2 == 0 || number % 3 == 0)
				{
					isPrime = false;
				}
				else
				{
					for(long i = 5; i * i <= number; i += 6)
					{
						if(number % i == 0 || number % (i + 2) == 0)
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