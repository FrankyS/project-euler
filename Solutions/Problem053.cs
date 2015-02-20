namespace ProjectEuler.Solutions
{
	using System.Numerics;
	using NUnit.Framework;

	/// <summary>
	/// Combinatoric selections.
	/// There are exactly ten ways of selecting three from five, 12345:
	/// <para>123, 124, 125, 134, 135, 145, 234, 235, 245, and 345</para>
	/// In combinatorics, we use the notation, <sup>5</sup>C<sub>3</sub> = 10.
	/// <para>In general,</para>
	/// <sup>n</sup>C<sub>r</sub> =	n! / r!(n−r)!
	/// <para>,where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.</para>
	/// It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.
	/// <para>How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?</para>
	/// </summary>
	public class Problem053 : Problem
	{
		public override long Solution()
		{
			long count = 0;
			BigInteger[] factorials = GetFactorials();

			for (int n = 0; n <= 100; n++)
			{
				for (int r = 0; r <= n; r++)
				{
					BigInteger value = factorials[n] / (factorials[r] * factorials[n - r]);
					if (value >= 1000000)
					{
						count++;
					}
				}
			}
			
			return count;
		}

		private static BigInteger[] GetFactorials()
		{
			BigInteger[] factorials = new BigInteger[101];
			
			factorials[0] = 1;
			for (int number = 1; number <= 100; number++)
			{
				factorials[number] = factorials[number - 1] * number;
			}

			return factorials;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(4075, this.Solution());
		}
	}
}