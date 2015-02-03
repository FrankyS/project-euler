namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	/// <summary>
	/// Lexicographic permutations.
	/// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
	/// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
	/// <para>
	/// 012   021   102   120   201   210
	/// </para>
	/// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
	/// </summary>
	public class Problem024 : Problem
	{
		public override long Solution()
		{
			int[] digits = Enumerable.Range(0, 10)
				.ToArray();
			List<string> permutations = GetPermutations(digits, 1000000);

			return long.Parse(permutations[999999]);
		}

		private List<string> GetPermutations(int[] digits, int maxPermutations)
		{
			List<string> permutations = new List<string>();
			for (int i = 0; i < digits.Length; i++)
			{
				string permutation = digits[i].ToString();
				if(digits.Length == 1)
				{
					permutations.Add(permutation);
				}
				else
				{
					int[] remainingDigits = GetRemainingDigits(digits, i);
					List<string> subPermutations = this.GetPermutations(remainingDigits, maxPermutations);
					foreach(string subPermutation in subPermutations)
					{
						permutations.Add(permutation + subPermutation);
					}
				}

				if(permutations.Count >= maxPermutations)
				{
					break;
				}
			}

			return permutations;
		}

		private static int[] GetRemainingDigits(int[] digits, int indexToRemove)
		{
			int[] remainingDigits = new int[digits.Length - 1];
			for(int i = 0; i < indexToRemove; i++)
			{
				remainingDigits[i] = digits[i];
			}

			for(int i = indexToRemove; i < remainingDigits.Length; i++)
			{
				remainingDigits[i] = digits[i + 1];
			}

			return remainingDigits;
		}

		[Test]
		public void TestForExample()
		{
			string[] expectedResult = new string[] { "012", "021", "102", "120", "201", "210" };
			int[] digits = Enumerable.Range(0, 3)
				.ToArray();
			List<string> result = GetPermutations(digits, 100);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(2783915460, this.Solution());
		}
	}
}