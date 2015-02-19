namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
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
			IEnumerator<long> primeFactor = Primes.GetPrimeFactors(600851475143)
				.GetEnumerator();
			while(primeFactor.MoveNext()) { }

			return primeFactor.Current;
		}

		[Test]
		public void TestForExample()
		{
			byte[] expectedFactors = new byte[] { 5, 7, 13, 29 };

			IEnumerable<long> primeFactors = Primes.GetPrimeFactors(13195);

			Assert.AreEqual(expectedFactors, primeFactors);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(6857, this.Solution());
		}
	}
}