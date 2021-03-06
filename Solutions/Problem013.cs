﻿namespace ProjectEuler.Solutions
{
	using System;
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
			string[] rows = Input.Problem013.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			int[][] numbers = new int[rows.Length][];
			for(int i = 0; i < rows.Length; i++)
			{
				numbers[i] = ArrayMath.ToDigitsArray(rows[i]);
			}

			int[] result = ArrayMath.Sum(numbers);
			string stringResult = string.Empty;
			for(int i = 0; i < 10; i++)
			{
				stringResult += result[i];
			}

			return long.Parse(stringResult);
		}

		[TestCase("11", "22", "33")]
		[TestCase("4", "21", "25")]
		[TestCase("14", "2", "16")]
		public void TestForSum(string first, string second, string expectedResult)
		{
			int[] result = ArrayMath.Sum(ArrayMath.ToDigitsArray(first), ArrayMath.ToDigitsArray(second));

			Assert.AreEqual(expectedResult, string.Join(string.Empty, result));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(5537376230, this.Solution());
		}
	}
}