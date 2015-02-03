namespace ProjectEuler.Solutions
{
	using System;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;
	using ProjectEuler.Input;

	/// <summary>
	/// Large sum.
	/// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
	/// </summary>
	/// <remarks>The digits are stored in the file <a href="Problem013.txt">Problem013.txt</a>.</remarks>
	public class Problem013 : Problem
	{
		public override long Solution()
		{
			int[][] numbers = Input.Problem013.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.ToDigitsArray())
				.ToArray();

			int[] result = MathHelper.Sum(numbers);
			return long.Parse(result.Take(10)
				.ToText());
		}

		[TestCase("11", "22", "33")]
		[TestCase("4", "21", "25")]
		[TestCase("14", "2", "16")]
		public void TestForSum(string first, string second, string expectedResult)
		{
			int[] result = MathHelper.Sum(first.ToDigitsArray(), second.ToDigitsArray());

			Assert.AreEqual(expectedResult, result.ToText());
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(5537376230, this.Solution());
		}
	}
}