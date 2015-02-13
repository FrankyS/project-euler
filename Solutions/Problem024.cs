namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
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
			List<string> permutations = new List<string>();
			Permutations("0123456789", permutations, 1000000, string.Empty);

			return long.Parse(permutations[999999]);
		}

		private static void Permutations(string source, ICollection<string> permutations, int maxPermutations, string permutation)
		{
			for(int i = 0; i < source.Length; i++)
			{
				if (permutations.Count >= maxPermutations)
				{
					break;
				}

				string newPermutation = permutation + source[i];
				string nextSource = source.Remove(i, 1);
				if(nextSource.Length == 0)
				{
					permutations.Add(newPermutation);
				}
				else
				{
					Permutations(nextSource, permutations, maxPermutations, newPermutation);
				}
			}
		}

		[Test]
		public void TestForExample()
		{
			string[] expectedResult = new[] { "012", "021", "102", "120", "201", "210" };

			List<string> permutations = new List<string>(6);
			Permutations("012", permutations, 6, string.Empty);
			
			Assert.AreEqual(expectedResult, permutations);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(2783915460, this.Solution());
		}
	}
}