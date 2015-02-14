namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Integer right triangles.
	/// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
	/// <para>{20,48,52}, {24,45,51}, {30,40,50}</para>
	/// For which value of p ≤ 1000, is the number of solutions maximised?
	/// </summary>
	public class Problem039 : Problem
	{
		public override long Solution()
		{
			long bestValueOfP = 0;
			long maximisedCount = 0;
			for (int p = 1; p <= 1000; p++)
			{
				long count = GetRightTriangleSolutions(p)
					.Length;

				if (count > maximisedCount)
				{
					maximisedCount = count;
					bestValueOfP = p;
				}
			}
			
			return bestValueOfP;
		}

		/// <summary>
		/// Determines the solutions in a right triangle for the given perimeter.
		/// </summary>
		/// <param name="p">The perimeter.</param>
		/// <returns>The possible solutions.</returns>
		/// <remarks>p = a + b + SQRT(a^2 + b^2)</remarks>
		private static int[][] GetRightTriangleSolutions(int p)
		{
			List<int[]> solutions = new List<int[]>();
			for (int a = 1; a < p / 3; a++)
			{
				int b = CalculateB(p, a);
				int c = CalculateC(a, b);
				if (a + b + c == p)
				{
					solutions.Add(new[] { a, b, c });
				}
			}

			return solutions.ToArray();
		}

		private static int CalculateB(int p, int a)
		{
			double b = ((0.5 * (p * p)) - (p * a)) / (p - a);
			return (int)b;
		}

		private static int CalculateC(int a, int b)
		{
			return (int)Math.Sqrt((a * a) + (b * b));
		}

		[Test]
		public void TestForExample()
		{
			int[][] expectedSolutions = new[] { new[] { 20, 48, 52 }, new[] { 24, 45, 51 }, new[] { 30, 40, 50 } };
			int[][] solutions = GetRightTriangleSolutions(120);

			Assert.AreEqual(expectedSolutions, solutions);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(840, this.Solution());
		}
	}
}