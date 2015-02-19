namespace ProjectEuler.Helper
{
	using System.Collections.Generic;

	public static class ArrayMath
	{
		public static int[] ToDigitsArray(string numberString)
		{
			int[] digits = new int[numberString.Length];
			for(int i = 0; i < numberString.Length; i++)
			{
				digits[i] = int.Parse(numberString[i].ToString());
			}

			return digits;
		}

		public static int[] Sum(params int[][] numbers)
		{
			int carry = 0;
			List<int> sumsPerDigit = new List<int>();

			int amountNumbers = numbers.Length;

			for (int digit = 1;; digit++)
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

		public static int ToNumber(int[] digits)
		{
			int number = 0;
			int factor = 1;
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				number += digits[i] * factor;
				factor *= 10;
			}

			return number;
		}
	}
}