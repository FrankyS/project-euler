namespace ProjectEuler.Solutions
{
	using System;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Factorial digit sum.
	/// n! means n × (n − 1) × ... × 3 × 2 × 1
	/// <para>
	/// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
	/// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
	/// </para>
	/// Find the sum of the digits in the number 100!
	/// </summary>
	public class Problem020 : Problem
	{
		public override long Solution()
		{
			int[] factorial = MathHelper.Factorial(100);
			return factorial.Sum();
		}

		[TestCase("11", "12", "132")]
		[TestCase("5", "12", "60")]
		[TestCase("15", "3", "45")]
		public void TestForMultiply(string first, string second, string expectedResult)
		{
			int[] result = MathHelper.Mulitply(first.ToDigitsArray(), second.ToDigitsArray());

			Assert.AreEqual(expectedResult, result.ToText());
		}

		[Test]
		public void TestForExample()
		{
			int[] factorial = MathHelper.Factorial(10);
			long sum = factorial.Sum();

			Assert.AreEqual(27, sum);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(648, this.Solution());
		}
	}
}