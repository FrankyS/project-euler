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
			int[] first = new[] { 1 };
			yield return first;

			int[] second = new[] { 2 };
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

		public static int[] Factorial(int number)
		{
			int[] factorial = { 1 };
			for (int i = 1; i <= number; i++)
			{
				factorial = Multiply(factorial, ToDigitsArray(i.ToString()));
			}

			return factorial;
		}

		public static int[] Multiply(int[] first, int[] second)
		{
			int count = first.Length + second.Length;
			int[] result = new int[0];
			for (int f = first.Length - 1; f >= 0; f--)
			{
				for (int s = second.Length - 1; s >= 0; s--)
				{
					int[] tmpResult = new int[count];
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

			int startIndex = 0;
			while(result[startIndex] == 0)
			{
				startIndex++;
			}

			int[] cleanedResult = new int[result.Length - startIndex];
			for(int i = 0; i < cleanedResult.Length; i++)
			{
				cleanedResult[i] = result[i + startIndex];
			}

			return cleanedResult;
		}
	}
}