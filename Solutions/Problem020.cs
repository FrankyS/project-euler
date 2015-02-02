namespace ProjectEuler.Solutions
{
	using System.Linq;
	using NUnit.Framework;

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
			throw new System.NotImplementedException();
		}

		private static string CalculateFactorial(int number)
		{
			long factorial = 1;
			for(int i = 1; i <= number; i++)
			{
				factorial *= i;
			}

			return factorial.ToString();
		}

		[Test]
		public void TestForExample()
		{
			string factorial = CalculateFactorial(10);
			long sum = factorial.Select(x => int.Parse(x.ToString()))
				.Sum();

			Assert.AreEqual(27, sum);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(0, this.Solution());
		}
	}
}