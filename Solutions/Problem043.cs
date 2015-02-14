namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Sub-string divisibility.
	/// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
	/// <para>Let d<sub>1</sub> be the 1st digit, d<sub>2</sub> be the 2nd digit, and so on. In this way, we note the following:</para>
	/// <para>d<sub>2</sub>d<sub>3</sub>d<sub>4</sub>=406 is divisible by 2</para>
	/// <para>d<sub>3</sub>d<sub>4</sub>d<sub>5</sub>=063 is divisible by 3</para>
	/// <para>d<sub>4</sub>d<sub>5</sub>d<sub>6</sub>=635 is divisible by 5</para>
	/// <para>d<sub>5</sub>d<sub>6</sub>d<sub>7</sub>=357 is divisible by 7</para>
	/// <para>d<sub>6</sub>d<sub>7</sub>d<sub>8</sub>=572 is divisible by 11</para>
	/// <para>d<sub>7</sub>d<sub>8</sub>d<sub>9</sub>=728 is divisible by 13</para>
	/// <para>d<sub>8</sub>d<sub>9</sub>d<sub>10</sub>=289 is divisible by 17</para>
	/// Find the sum of all 0 to 9 pandigital numbers with this property.
	/// </summary>
	public class Problem043 : Problem
	{
		private static readonly int[] divisors = new int[] { 2, 3, 5, 7, 11, 13, 17 };

		public override long Solution()
		{
			long sum = 0;
			List<string> permutations = new List<string>();
			Problem024.Permutations("0123456789", permutations);
			foreach (string permutation in permutations)
			{
				if (Problem032.IsPandigital(permutation, 10, '0'))
				{
					if (IsSubStringDivisable(permutation))
					{
						sum += long.Parse(permutation);
					}
				}
			}

			return sum;
		}

		private static bool IsSubStringDivisable(string numberString)
		{
			bool isSubStringDivisable = true;
			for (int i = 0; i < 7; i++)
			{
				string substring = numberString.Substring(i + 1, 3);
				long subNumber = long.Parse(substring);
				if (subNumber % divisors[i] != 0)
				{
					isSubStringDivisable = false;
				}
			}

			return isSubStringDivisable;
		}

		[Test]
		public void TestForExample()
		{
			Assert.IsTrue(IsSubStringDivisable("1406357289"));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(16695334890, this.Solution());
		}
	}
}