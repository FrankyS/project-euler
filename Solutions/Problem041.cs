namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Pandigital prime.
	/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
	/// <para>What is the largest n-digit pandigital prime that exists?</para>
	/// </summary>
	public class Problem041 : Problem
	{
		public override long Solution()
		{
			long largestPandigitalPrime = 0;
			int[] primes = Problem010.EratosthenesSieve(7654321).ToArray();

			for (int i = primes.Length - 1; i >= 0; i--)
			{
				long prime = primes[i];
				string primeString = prime.ToString();
				if (Problem032.IsPandigital(primeString, primeString.Length))
				{
					largestPandigitalPrime = prime;
					break;
				}
			}

			return largestPandigitalPrime;
		}

		[Test]
		public void TestForExample()
		{
			const int number = 2143;

			Assert.IsTrue(Problem003.IsPrimeNumber(number));
			Assert.IsTrue(Problem032.IsPandigital(number.ToString(), 4));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(7652413, this.Solution());
		}
	}
}