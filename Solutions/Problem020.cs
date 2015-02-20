namespace ProjectEuler.Solutions
{
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
			int[] factorial = ArrayMath.Factorial(100);
			long sum = 0;
			foreach(int digit in factorial)
			{
				sum += digit;
			}

			return sum;
		}

		[TestCase("11", "12", "132")]
		[TestCase("5", "12", "60")]
		[TestCase("15", "3", "45")]
		public void TestForMultiply(string first, string second, string expectedResult)
		{
			int[] result = ArrayMath.Multiply(ArrayMath.ToDigitsArray(first), ArrayMath.ToDigitsArray(second));

			Assert.AreEqual(expectedResult, string.Join(string.Empty, result));
		}

		[Test]
		public void TestForExample()
		{
			int[] expectedFactorial = new int[] { 3, 6, 2, 8, 8, 0, 0 };
			int[] factorial = ArrayMath.Factorial(10);

			Assert.AreEqual(expectedFactorial, factorial);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(648, this.Solution());
		}
	}
}