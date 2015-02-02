namespace ProjectEuler.Helper
{
	using System.Linq;

	public static class NumberHelper
	{
		public static int[] ToDigitsArray(this string numberString)
		{
			return numberString.Select(x => int.Parse(x.ToString()))
				.ToArray();
		}
	}
}