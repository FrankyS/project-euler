namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;

	/// <summary>
	/// Special Pythagorean triplet.
	/// A Pythagorean triplet is a set of three natural numbers, a &lt; b &lt; c, for which,
	/// <para>a<sup>2</sup> + b<sup>2</sup> = c<sup>2</sup></para>
	/// For example, 3<sup>2</sup> + 4<sup>2</sup> = 9 + 16 = 25 = 5<sup>2</sup>.
	/// <para>There exists exactly one Pythagorean triplet for which a + b + c = 1000.</para>
	/// Find the product abc.
	/// </summary>
	public class Problem009 : Problem
	{
		public override long Solution()
		{
			return PythagoreanTriplet(1000);
		}

		private static long PythagoreanTriplet(int targetSum)
		{
			long product = 0;
			for (int a = 1; a < targetSum / 3; a++)
			{
				for (int b = a + 1; b < targetSum / 2; b++)
				{
					int c = targetSum - b - a;
					if (Equals(Math.Pow(a, 2) + Math.Pow(b, 2), Math.Pow(c, 2)))
					{
						product = a * b * c;
						a = targetSum;
						break;
					}
				}
			}

			return product;
		}

		[Test]
		public void TestForExample()
		{
			long product = PythagoreanTriplet(12);

			Assert.AreEqual(60, product);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(31875000, this.Solution());
		}
	}
}