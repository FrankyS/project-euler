namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;
	using ProjectEuler.Input;

	/// <summary>
	/// Largest product in a grid.
	/// In the 20×20 grid, four numbers along a diagonal line have been marked in bold.
	/// <para>What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?</para>
	/// </summary>
	/// <remarks>The grid is stored in the file <a href="Problem011.txt">Problem011.txt</a>.</remarks>
	public class Problem011 : Problem
	{
		public override long Solution()
		{
			long largestProduct = 0;

			string gridInput = Input.Problem011;
			byte[,] grid = CreateGrid(gridInput);

			int maxY = grid.GetUpperBound(0);
			int maxX = grid.GetUpperBound(1);
			for (int y = 0; y < maxY; y++)
			{
				for (int x = 0; x < maxX; x++)
				{
					if (x <= maxX - 3)
					{
						largestProduct = LargestProduct(largestProduct, grid, x, y, 1, 0);
						if (y >= 3)
						{
							largestProduct = LargestProduct(largestProduct, grid, x, y, 1, -1);
						}

						if (y <= maxY - 3)
						{
							largestProduct = LargestProduct(largestProduct, grid, x, y, 1, 1);
						}
					}

					if (y <= maxY - 3)
					{
						largestProduct = LargestProduct(largestProduct, grid, x, y, 0, 1);
					}
				}
			}

			return largestProduct;
		}

		private static byte[,] CreateGrid(string gridInput)
		{
			string[] rows = gridInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			byte[,] grid = new byte[20, 20];
			for(int x = 0; x < 20; x++)
			{
				string[] row = rows[x].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				for(int y = 0; y < 20; y++)
				{
					grid[x, y] = byte.Parse(row[y]);
				}
			}

			return grid;
		}

		private static long LargestProduct(long currentLargest, byte[,] grid, int x, int y, int xOffset, int yOffset)
		{
			long currentProduct = grid[y, x] *
				grid[y + yOffset, x + xOffset] *
				grid[y + (yOffset * 2), x + (xOffset * 2)] *
				grid[y + (yOffset * 3), x + (xOffset * 3)];

			return currentLargest > currentProduct
				? currentLargest
				: currentProduct;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(70600674, this.Solution());
		}
	}
}