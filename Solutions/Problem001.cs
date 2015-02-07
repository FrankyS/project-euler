namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Multiples of 3 and 5.
	/// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
	/// <para>Find the sum of all the multiples of 3 or 5 below 1000.</para>
	/// </summary>
	public class Problem001 : Problem
	{
		public override long Solution()
		{
			return SumMultiples(1000);
		}

		private static int SumMultiples(int upperBound)
		{
			int sum = 0;
			for (int value = 0; value < upperBound; value++)
			{
				if (value % (long)3 == 0 || value % (long)5 == 0)
				{
					sum += value;
				}
			}

			return sum;
		}

		[Test]
		public void TestForExample()
		{
			long result = SumMultiples(10);

			Assert.AreEqual(23, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(233168, this.Solution());
		}
	}
}