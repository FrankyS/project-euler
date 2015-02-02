namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;
	using ProjectEuler.Input;

	/// <summary>
	/// Maximum path sum I.
	/// By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
	/// <para>   3   </para>
	/// <para>  7 4  </para>
	/// <para> 2 4 6 </para>
	/// <para>8 5 9 3</para>
	/// That is, 3 + 7 + 4 + 9 = 23.
	/// <para>Find the maximum total from top to bottom of the triangle below.</para>
	/// <b>NOTE</b>: As there are only 16384 routes, it is possible to solve this problem by trying every route.
	/// However, <see cref="Problem067"/>, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
	/// </summary>
	/// <remarks>The digits are stored in the file <a href="Problem018.txt">Problem018.txt</a>.</remarks>
	public class Problem018 : Problem
	{
		public override long Solution()
		{
			return GetMaximumPath(Input.Problem018);
		}

		private static long GetMaximumPath(string input)
		{
			int[][] triangle = CreateTriangle(input);
			Node root = Node.CreateTree(triangle, 0, 0, new Dictionary<Point, Node>());

			return root.Value;
		}

		private static int[][] CreateTriangle(string input)
		{
			string[] rows = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			return rows
				.Select(x => x.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(y => int.Parse(y))
					.ToArray())
				.ToArray();
		}

		[Test]
		public void TestForExample()
		{
			const string smallTriangle = @"
   3
  7 4
 2 4 6
8 5 9 3";

			long maximumPath = GetMaximumPath(smallTriangle);

			Assert.AreEqual(23, maximumPath);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(1074, this.Solution());
		}
	}
}