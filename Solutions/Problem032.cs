namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Pandigital products.
	/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
	/// <para>
	/// The product 7254 is unusual, as the identity, 39 � 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
	/// </para>
	/// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
	/// </summary>
	/// <remarks>
	/// <b>HINT:</b> Some products can be obtained in more than one way so be sure to only include it once in your sum.
	/// </remarks>
	public class Problem032 : Problem
	{
		public override long Solution()
		{
			ICollection<int> pandigitalProducts = new HashSet<int>();
			for(int multiplicand = 1; multiplicand < 100; multiplicand++)
			{
				for(int multiplier = multiplicand; multiplier < 10000; multiplier++)
				{
					int product = multiplicand * multiplier;
					if(IsPandigital(multiplicand, multiplier, product))
					{
						pandigitalProducts.Add(product);
					}
				}
			}

			long sum = 0;
			foreach (int pandigitalProduct in pandigitalProducts)
			{
				sum += pandigitalProduct;
			}

			return sum;
		}

		private static bool IsPandigital(int multiplicand, int multiplier, int product)
		{
			ICollection<char> occuringDigits = new HashSet<char> { '0' };
			string pandigitalProduct = string.Format("{0}{1}{2}", multiplicand, multiplier, product);
			foreach (char digit in pandigitalProduct)
			{
				if (occuringDigits.Contains(digit))
				{
					return false;
				}
				occuringDigits.Add(digit);
			}

			return pandigitalProduct.Length == 9;
		}

		[Test]
		public void TestForExample()
		{
			const int multiplicand = 39;
			const int multiplier = 186;
			const int product = multiplicand * multiplier;

			Assert.IsTrue(IsPandigital(multiplicand, multiplier, product));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(45228, this.Solution());
		}
	}
}