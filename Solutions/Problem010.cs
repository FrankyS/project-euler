namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Summation of primes.
	/// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
	/// <para>Find the sum of all the primes below two million.</para>
	/// </summary>
	public class Problem010 : Problem
	{
		public override long Solution()
		{
			return SumOfPrimes(2000000);
		}

		private static long SumOfPrimes(long upperBound)
		{
			long sum = 0;
			foreach(long primeNumber in Problem003.GetPrimeNumber())
			{
				if(primeNumber >= upperBound)
				{
					break;
				}
				sum += primeNumber;
			}

			return sum;
		}

		[Test]
		public void TestForExample()
		{
			long sumOfPrimes = SumOfPrimes(10);

			Assert.AreEqual(17, sumOfPrimes);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(142913828922, this.Solution());
		}
	}
}