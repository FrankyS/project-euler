namespace ProjectEuler.Helper
{
	using System.Collections.Generic;
	using System.Linq;

	public static class NumberHelper
	{
		public static int[] ToDigitsArray(this string numberString)
		{
			return numberString.Select(x => int.Parse(x.ToString()))
				.ToArray();
		}

		public static int[] ToDigitsArray(this int number)
		{
			return number.ToString().ToDigitsArray();
		}

		public static string ToText(this IEnumerable<int> number)
		{
			return string.Join(string.Empty, number);
		}
	}
}