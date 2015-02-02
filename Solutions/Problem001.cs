namespace ProjectEuler.Solutions
{
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Multiples of 3 and 5.
	/// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
	/// <para>Find the sum of all the multiples of 3 or 5 below 1000.</para>
	/// </summary>
	public class Problem001 : Problem
	{
		private readonly long[] divisors = new long[] { 3, 5 };

		public override long Solution()
		{
			return MathHelper.SumMultiples(1000, divisors);
		}

		[Test]
		public void TestForExample()
		{
			long result = MathHelper.SumMultiples(10, divisors);

			Assert.AreEqual(23, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(233168, this.Solution());
		}
	}
}