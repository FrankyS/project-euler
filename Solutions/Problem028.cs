namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Number spiral diagonals.
	/// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
	/// <para>
	/// 21 22 23 24 25
	/// 20  7  8  9 10
	/// 19  6  1  2 11
	/// 18  5  4  3 12
	/// 17 16 15 14 13
	/// </para>
	/// It can be verified that the sum of the numbers on the diagonals is 101.
	/// <para>What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?</para>
	/// </summary>
	public class Problem028 : Problem
	{
		public override long Solution()
		{
			long sumOfDiagonals = 0;

			const int size = 1001;
			int[,] spiral = CreateSpiral(size);
			for(int i = 0; i < size; i++)
			{
				sumOfDiagonals += spiral[i, i];
				sumOfDiagonals += spiral[size - i - 1, i];
			}

			sumOfDiagonals -= spiral[500, 500];

			return sumOfDiagonals;
		}

		private static int[,] CreateSpiral(int size)
		{
			int[,] spiral = new int[size, size];
			
			int[][] directions = new int[][]
				{
					new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 }
				};

			int directionIndex = 0;
			int currentLength = 0;
			int stepLength = 1;
			
			int x = size / 2;
			int y = x;
			for(int i = 1; i <= size * size; i++)
			{
				spiral[x, y] = i;

				int[] direction = directions[directionIndex];
				x += direction[0];
				y += direction[1];

				currentLength++;
				if(currentLength == stepLength)
				{
					currentLength = 0;
					directionIndex = (directionIndex + 1) % 4;
					if(directionIndex % 2 == 0)
					{
						stepLength++;
					}
				}
			}

			return spiral;
		}

		[Test]
		public void TestForExample()
		{
			long sumOfDiagonals = 0;

			const int size = 5;
			int[,] spiral = CreateSpiral(size);
			for (int i = 0; i < size; i++)
			{
				sumOfDiagonals += spiral[i, i];
				sumOfDiagonals += spiral[size - i - 1, i];
			}

			sumOfDiagonals -= spiral[2, 2];
			Assert.AreEqual(101, sumOfDiagonals);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(669171001, this.Solution());
		}
	}
}