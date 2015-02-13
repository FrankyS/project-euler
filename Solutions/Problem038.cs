namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Pandigital multiples.
	/// Take the number 192 and multiply it by each of 1, 2, and 3:
	/// <para>192 × 1 = 192</para>
	/// <para>192 × 2 = 384</para>
	/// <para>192 × 3 = 576</para>
	/// By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)
	/// <para>
	/// The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
	/// </para>
	/// What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?
	/// </summary>
	public class Problem038 : Problem
	{
		public override long Solution()
		{
			long largestPandigital = 0;
			for (int number = 1; number < 10000; number++)
			{
				for (int n = 2; n < 9; n++)
				{
					string products = ConcatenateProducts(number, n);
					if (Problem032.IsPandigital(products))
					{
						long pandigital = long.Parse(products);
						if (pandigital > largestPandigital)
						{
							largestPandigital = pandigital;
						}
					}
				}
			}

			return largestPandigital;
		}

		private static string ConcatenateProducts(long number, int maxMultiplier)
		{
			string products = number.ToString();
			for (int i = 2; i <= maxMultiplier; i++)
			{
				products += number * i;
			}

			return products;
		}

		[Test]
		public void TestForExample()
		{
			string product = ConcatenateProducts(192, 3);

			Assert.AreEqual("192384576", product);
			Assert.IsTrue(Problem032.IsPandigital(product));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(932718654, this.Solution());
		}
	}
}