namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Pandigital products.
	/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
	/// <para>
	/// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
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
					string pandigitalProduct = string.Format("{0}{1}{2}", multiplicand, multiplier, product);
					if(IsPandigital(pandigitalProduct))
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

		public static bool IsPandigital(string pandigitalProduct, int n = 9)
		{
			bool isPandigital = pandigitalProduct.Length == n;
			if (isPandigital)
			{
				char[] charArray = pandigitalProduct.ToCharArray();
				Array.Sort(charArray);
				for (int i = 0; i < charArray.Length; i++)
				{
					int expectedChar = '1' + i;
					if (charArray[i] != expectedChar)
					{
						isPandigital = false;
					}
				}
			}

			return isPandigital;
		}

		[Test]
		public void TestForExample()
		{
			const int multiplicand = 39;
			const int multiplier = 186;
			const int product = multiplicand * multiplier;
			string pandigitalProduct = string.Format("{0}{1}{2}", multiplicand, multiplier, product);

			Assert.IsTrue(IsPandigital(pandigitalProduct));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(45228, this.Solution());
		}
	}
}