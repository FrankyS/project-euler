namespace ProjectEuler.Solutions
{
	using NUnit.Framework;
	using ProjectEuler.Helper;
	using ProjectEuler.Input;

	/// <summary>
	/// Largest product in a series.
	/// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
	/// <para>Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?</para>
	/// </summary>
	/// <remarks>The 1000-digit number is stored in the file <a href="Problem008.txt">Problem008.txt</a>.</remarks>
	public class Problem008 : Problem
	{
		public override long Solution()
		{
			return LargestProduct(13);
		}

		private static long LargestProduct(int amountAdjacent)
		{
			long largestProduct = 0;

			string giantNumber = Input.Problem008;
			byte[] digits = ArrayMath.ToDigitsArray(giantNumber);

			for (int i = 0; i < digits.Length - 1 - amountAdjacent; i++)
			{
				long currentProduct = 1;
				for (int j = 0; j < amountAdjacent; j++)
				{
					currentProduct *= digits[i + j];
				}

				if (currentProduct > largestProduct)
				{
					largestProduct = currentProduct;
				}
			}

			return largestProduct;
		}

		[Test]
		public void TestForExample()
		{
			long result = LargestProduct(4);

			Assert.AreEqual(5832, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(23514624000, this.Solution());
		}
	}
}