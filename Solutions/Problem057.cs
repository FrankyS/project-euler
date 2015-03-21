namespace ProjectEuler.Solutions
{
	using System;
	using System.Numerics;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Square root convergents.
	/// It is possible to show that the square root of two can be expressed as an infinite continued fraction.
	/// <para>Math.Sqrt(2) = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...</para>
	/// By expanding this for the first four iterations, we get:
	/// <para>1 + 1/2 = 3/2 = 1.5</para>
	/// <para>1 + 1/(2 + 1/2) = 7/5 = 1.4</para>
	/// <para>1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...</para>
	/// <para>1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...</para>
	/// The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, 
	/// is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.
	/// <para>In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?</para>
	/// </summary>
	public class Problem057 : Problem
	{
		public override long Solution()
		{
			long solution = 0;

			Fraction fraction = new Fraction(1, 1);
			for (int i = 0; i < 1000; i++)
			{
				Converge(fraction);
				if (fraction.Numerator.Length() > fraction.Denominator.Length())
				{
					solution++;
				}
			}

			return solution;
		}

		private static void Converge(Fraction fraction)
		{
			// Add the denominator to the numerator
			fraction.Numerator += fraction.Denominator;

			// Swap numerator and denominator
			fraction.Swap();

			// Add the denominator to the numerator again to get the result
			fraction.Numerator += fraction.Denominator;
		}

		private class Fraction
		{
			public Fraction(BigInteger numerator, BigInteger denominator)
			{
				this.Numerator = numerator;
				this.Denominator = denominator;
			}

			public BigInteger Numerator { get; set; }

			public BigInteger Denominator { get; set; }

			public void Swap()
			{
				BigInteger oldNumerator = this.Numerator;
				this.Numerator = this.Denominator;
				this.Denominator = oldNumerator;
			}
		}

		[TestCase(1, 1, 3, 2)]
		[TestCase(3, 2, 7, 5)]
		[TestCase(7, 5, 17, 12)]
		[TestCase(17, 12, 41, 29)]
		[TestCase(41, 29, 99, 70)]
		[TestCase(99, 70, 239, 169)]
		[TestCase(239, 169, 577, 408)]
		[TestCase(577, 408, 1393, 985)]
		public void TestForExample(long initialNumerator, long initialDenominator, long expectedNominator, long expectedDenominator)
		{
			Fraction fraction = new Fraction(initialNumerator, initialDenominator);
			Converge(fraction);

			Assert.AreEqual((BigInteger)expectedNominator, fraction.Numerator);
			Assert.AreEqual((BigInteger)expectedDenominator, fraction.Denominator);
		}

		[Test]
		public void TestForSolution()
		{
			Assert.AreEqual(153, this.Solution());
		}
	}
}