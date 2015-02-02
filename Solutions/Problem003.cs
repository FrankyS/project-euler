namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Largest prime factor.
	/// The prime factors of 13195 are 5, 7, 13 and 29.
	/// <para>What is the largest prime factor of the number 600851475143?</para>
	/// </summary>
	public class Problem003 : Problem
	{
		public override long Solution()
		{
			IEnumerable<long> primeFactors = MathHelper.GetPrimeFactors(600851475143);
			return primeFactors.Last();
		}

		[Test]
		public void TestForExample()
		{
			long[] expectedFactors = new long[] { 5, 7, 13, 29 };

			IEnumerable<long> primeFactors = MathHelper.GetPrimeFactors(13195);

			Assert.AreEqual(expectedFactors, primeFactors);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(6857, this.Solution());
		}
	}
}