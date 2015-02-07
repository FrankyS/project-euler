namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
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
			byte[][] triangle = CreateTriangle(input);
			Node root = Node.CreateTree(triangle);

			return root.Value;
		}

		private static byte[][] CreateTriangle(string input)
		{
			string[] rows = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			byte[][] triangle = new byte[rows.Length][];
			for(int x = 0; x < rows.Length; x++)
			{
				string[] row = rows[x].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				triangle[x] = new byte[row.Length];
				for(int y = 0; y < row.Length; y++)
				{
					triangle[x][y] = byte.Parse(row[y]);
				}
			}

			return triangle;
		}

		private class Node
		{
			private readonly Node[] children = new Node[2];

			private Node(long value)
			{
				this.Value = value;
			}

			public long Value { get; private set; }

			public static Node CreateTree(byte[][] data, int x = 0, int y = 0, IDictionary<string, Node> knownNodes = null)
			{
				if (knownNodes == null)
				{
					knownNodes = new Dictionary<string, Node>();
				}

				string point = x + "|" + y;
				Node node = knownNodes.ContainsKey(point)
					? knownNodes[point]
					: null;
				if (node == null && x < data.Length && y < data[x].Length)
				{
					node = new Node(data[x][y]);
					node.CreateChildNode(data, x + 1, y, knownNodes);
					node.CreateChildNode(data, x + 1, y + 1, knownNodes);

					long maxhChildValue = 0;
					for (int i = 0; i < 2; i++)
					{
						Node childNode = node.children[i];
						if (childNode != null && childNode.Value > maxhChildValue)
						{
							maxhChildValue = childNode.Value;
						}
					}

					node.Value += maxhChildValue;

					knownNodes.Add(point, node);
				}

				return node;
			}

			private void CreateChildNode(byte[][] data, int x, int y, IDictionary<string, Node> knownNodes)
			{
				Node childNode = CreateTree(data, x, y, knownNodes);
				if (childNode != null)
				{
					if (this.children[0] == null)
					{
						this.children[0] = childNode;
					}
					else
					{
						this.children[1] = childNode;
					}
				}
			}
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