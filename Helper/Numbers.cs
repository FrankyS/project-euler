namespace ProjectEuler.Helper
{
	using System;

	public static class Numbers
	{
		public static bool IsPandigital(string pandigitalProduct, int n = 9, char startChar = '1')
		{
			bool isPandigital = pandigitalProduct.Length == n;
			if (isPandigital)
			{
				char[] charArray = pandigitalProduct.ToCharArray();
				Array.Sort(charArray);
				for (int i = 0; i < charArray.Length; i++)
				{
					int expectedChar = startChar + i;
					if (charArray[i] != expectedChar)
					{
						isPandigital = false;
					}
				}
			}

			return isPandigital;
		}

		public static bool IsTriangleNumber(long number)
		{
			double result = (Math.Sqrt((8 * number) + 1) - 1) / 2;
			return result.Equals((int)result);
		}

		public static int GetStringValue(string name)
		{
			int nameValue = 0;
			foreach(char c in name)
			{
				nameValue += c - 64;
			}

			return nameValue;
		}

		public static bool IsPentagonNumber(long number)
		{
			double result = (Math.Sqrt((24 * number) + 1) + 1) / 6;
			return result.Equals((int)result);
		}
	}
}