﻿namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Distinct powers.
	/// Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:
	/// <para>2<sup>2</sup>=4,  2<sup>3</sup>=8,   2<sup>4</sup>=16,  2<sup>5</sup>=32</para>
	/// <para>3<sup>2</sup>=9,  3<sup>3</sup>=27,  3<sup>4</sup>=81,  3<sup>5</sup>=243</para>
	/// <para>4<sup>2</sup>=16, 4<sup>3</sup>=64,  4<sup>4</sup>=256, 4<sup>5</sup>=1024</para>
	/// <para>5<sup>2</sup>=25, 5<sup>3</sup>=125, 5<sup>4</sup>=625, 5<sup>5</sup>=3125</para>
	/// If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:
	/// <para>4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125</para>
	/// How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
	/// </summary>
	public class Problem029 : Problem
	{
		public override long Solution()
		{
			return GetDistinctTerms(2, 100).Count;
		}

		private static HashSet<string> GetDistinctTerms(int lowerBound, int upperBound)
		{
			HashSet<string> terms = new HashSet<string>();
			for (int a = lowerBound; a <= upperBound; a++)
			{
				for (int b = lowerBound; b <= upperBound; b++)
				{
					double pow = Math.Pow(a, b);
					terms.Add(pow.ToString());
				}
			}

			return terms;
		}

		[Test]
		public void TestForExample()
		{
			long[] expectedTerms = new long[] { 4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125 };

			long[] distinctTerms = GetDistinctTerms(2, 5)
				.Select(x => long.Parse(x))
				.OrderBy(x => x)
				.ToArray();

			Assert.AreEqual(expectedTerms, distinctTerms);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(9183, this.Solution());
		}
	}
}