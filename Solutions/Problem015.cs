namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Lattice paths.
	/// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
	/// <para>How many such routes are there through a 20×20 grid?</para>
	/// </summary>
	public class Problem015 : Problem
	{
		public override long Solution()
		{
			return GetAmountRoutes(20);
		}

		private static long GetAmountRoutes(int gridSize)
		{
			long[,] grid = new long[gridSize, gridSize];
			for (int x = 0; x < gridSize; x++)
			{
				for (int y = 0; y < gridSize; y++)
				{
					if (x == 0)
					{
						if (y == 0)
						{
							grid[x, y] = 2;
						}
						else
						{
							grid[x, y] = grid[x, y - 1] + 1;
						}
					}
					else
					{
						if (y == 0)
						{
							grid[x, y] = grid[x - 1, y] + 1;
						}
						else
						{
							grid[x, y] = grid[x - 1, y] + grid[x, y - 1];
						}
					}
				}
			}

			return grid[gridSize - 1, gridSize - 1];
		}

		[Test]
		public void TestForExample()
		{
			long amountRoutes = GetAmountRoutes(2);

			Assert.AreEqual(6, amountRoutes);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(137846528820, this.Solution());
		}
	}
}