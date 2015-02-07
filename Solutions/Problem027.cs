namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Quadratic primes.
	/// Euler discovered the remarkable quadratic formula:
	/// <para>n<sup>2</sup> + n + 41</para>
	/// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
	/// However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
	/// <para>
	/// The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. 
	/// The product of the coefficients, −79 and 1601, is −126479.
	/// </para>
	/// Considering quadratics of the form:
	/// <para>n² + an + b, where |a| &lt; 1000 and |b| &lt; 1000</para>
	/// where |n| is the modulus/absolute value of n e.g. |11| = 11 and |−4| = 4
	/// <para>Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.</para>
	/// </summary>
	public class Problem027 : Problem
	{
		public override long Solution()
		{
			long coefficientsProduct = 0;
			int amountConsecutiveValues = 0;
			for(int a = -1000; a <= 1000; a++)
			{
				for(int b = -1000; b <= 1000; b++)
				{
					int counter = 0;
					long value;
					do
					{
						value = GetValue(counter++, a, b);
					} 
					while(Problem003.IsPrimeNumber(value));
					counter--;

					if(counter > amountConsecutiveValues)
					{
						amountConsecutiveValues = counter;
						coefficientsProduct = a * b;
					}
				}
			}

			return coefficientsProduct;
		}

		private static long GetValue(int number, int a, int b)
		{
			return (number * number) + (a * number) + b;
		}

		[Test]
		public void TestForExample()
		{
			for(int i = 0; i <= 39; i++)
			{
				Assert.IsTrue(Problem003.IsPrimeNumber(GetValue(i, 1, 41)));
			}

			Assert.IsFalse(Problem003.IsPrimeNumber(GetValue(40, 1, 41)));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(-59231, this.Solution());
		}
	}
}