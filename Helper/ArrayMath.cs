namespace ProjectEuler.Helper
{
	using System;
	using System.Collections.Generic;

	public static class ArrayMath
	{
		public static byte[] ToDigitsArray(string numberString)
		{
			byte[] digits = new byte[numberString.Length];
			for(int i = 0; i < numberString.Length; i++)
			{
				digits[i] = byte.Parse(numberString[i].ToString());
			}

			return digits;
		}

		public static byte[] Sum(params byte[][] numbers)
		{
			int carry = 0;
			List<byte> sumsPerDigit = new List<byte>();

			int amountNumbers = numbers.Length;

			for (int digit = 1;; digit++)
			{
				bool foundDigits = false;
				int sum = carry;
				for (byte number = 0; number < amountNumbers; number++)
				{
					byte[] digits = numbers[number];
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

				sumsPerDigit.Insert(0, (byte)(sum % 10));
				carry = sum / 10;
			}

			while (carry > 0)
			{
				sumsPerDigit.Insert(0, (byte)(carry % 10));
				carry /= 10;
			}

			return sumsPerDigit.ToArray();
		}

		public static IEnumerable<byte[]> GetFibonacciAsArray()
		{
			byte[] first = new byte[] { 1 };
			yield return first;

			byte[] second = new byte[] { 2 };
			yield return second;

			while (true)
			{
				byte[] next = Sum(first, second);
				first = second;
				second = next;

				if (next.Length > int.MaxValue)
				{
					yield break;
				}

				yield return next;
			}
		}
	}
}