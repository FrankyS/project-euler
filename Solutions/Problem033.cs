namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;

	/// <summary>
	/// Digit cancelling fractions.
	/// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
	/// <para>We shall consider fractions like, 30/50 = 3/5, to be trivial examples.</para>
	/// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
	/// <para>If the product of these four fractions is given in its lowest common terms, find the value of the denominator.</para>
	/// </summary>
	public class Problem033 : Problem
	{
		public override long Solution()
		{
			int numProduct = 1;
			int denProduct = 1;
			for(int numerator = 11; numerator < 99; numerator++)
			{
				for(int denominator = numerator + 1; denominator < 100; denominator++)
				{
					double expected = (double)numerator / denominator;

					int newNum;
					int newDen;

					string numString = numerator.ToString();
					string denString = denominator.ToString();
					if (numString[0] == denString[1])
					{
						newNum = numString[1] - 48;
						newDen = denString[0] - 48;
					}
					else if(numString[1] == denString[0])
					{
						newNum = numString[0] - 48;
						newDen = denString[1] - 48;
					}
					else
					{
						continue;
					}

					if(expected.Equals((double)newNum / newDen))
					{
						numProduct *= numerator;
						denProduct *= denominator;
					}
				}
			}

			int commonDenominator = 2;
			while(commonDenominator <= numProduct)
			{
				if(numProduct % commonDenominator == 0 && denProduct % commonDenominator == 0)
				{
					numProduct /= commonDenominator;
					denProduct /= commonDenominator;
				}
				else
				{
					commonDenominator++;
				}
			}

			return denProduct;
		}

		[Test]
		public void TestForExample()
		{
			const double fraction1 = 49d / 98;
			const double fraction2 = 4d / 8;

			Assert.AreEqual(fraction1, fraction2);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(100, this.Solution());
		}
	}
}