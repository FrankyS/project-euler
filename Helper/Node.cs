namespace ProjectEuler.Helper
{
	using System.Collections.Generic;
	using System.Linq;

	public class Node
	{
		private Node(long value)
		{
			this.Value = value;
			this.Children = new List<Node>(2);
		}

		public long Value { get; private set; }

		public List<Node> Children { get; private set; }

		public static Node CreateTree(int[][] data, int x, int y, Dictionary<Point, Node> knownNodes)
		{
			Point point = new Point(x, y);
			Node node = knownNodes.ContainsKey(point)
				? knownNodes[point]
				: null;
			if (node == null && x < data.Length && y < data[x].Length)
			{
				node = new Node(data[x][y]);
				knownNodes.Add(point, node);
				CreateChildNode(data, x + 1, y, knownNodes, node);
				CreateChildNode(data, x + 1, y + 1, knownNodes, node);

				if (node.Children.Any())
				{
					node.Value += node.Children.Max(child => child.Value);
				}
			}

			return node;
		}

		private static void CreateChildNode(int[][] data, int x, int y, Dictionary<Point, Node> knownNodes, Node node)
		{
			Node childNode = CreateTree(data, x, y, knownNodes);
			if (childNode != null)
			{
				node.Children.Add(childNode);
			}
		}
	}
}