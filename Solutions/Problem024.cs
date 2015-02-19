namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

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
			List<string> permutations = Permutation.GetPermutations("0123456789", 1000000);

			return long.Parse(permutations[999999]);
		}

		[Test]
		public void TestForExample()
		{
			string[] expectedResult = new[] { "012", "021", "102", "120", "201", "210" };

			List<string> permutations = Permutation.GetPermutations("012");
			
			Assert.AreEqual(expectedResult, permutations);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(2783915460, this.Solution());
		}
	}
}