namespace ProjectEuler.Helper
{
	using System.Collections.Generic;

	public static class Permutation
	{
		public static List<string> GetPermutations(string source, int maxPermutations = int.MaxValue)
		{
			List<string> permutations = new List<string>();
			GetPermutations(source, permutations, maxPermutations);

			return permutations;
		}

		private static void GetPermutations(string source, ICollection<string> permutations, int maxPermutations = int.MaxValue, string permutation = null)
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
					GetPermutations(nextSource, permutations, maxPermutations, newPermutation);
				}
			}
		}
	}
}