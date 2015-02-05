﻿namespace ProjectEuler.Solutions
{
	using System.Linq;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Highly divisible triangular number.
	/// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
	/// <para>1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...</para>
	/// Let us list the factors of the first seven triangle numbers:
	/// <para>
	///  1: 1
	///  3: 1,3
	///  6: 1,2,3,6
	/// 10: 1,2,5,10
	/// 15: 1,3,5,15
	/// 21: 1,3,7,21
	/// 28: 1,2,4,7,14,28
	/// </para>
	/// We can see that 28 is the first triangle number to have over five divisors.
	/// <para>What is the value of the first triangle number to have over five hundred divisors?</para>
	/// </summary>
	public class Problem012 : Problem
	{
		public override long Solution()
		{
			return FirstTriangleNumberWithAmountDivisors(500);
		}

		private static long FirstTriangleNumberWithAmountDivisors(int targetAmountDivisors)
		{
			long triangleNumber = 0;
			for (long i = 1;; i++)
			{
				triangleNumber += i;
				long[] primeFactors = MathHelper.GetPrimeFactors(triangleNumber)
					.ToArray();

				int amountDivisors = primeFactors
					.GroupBy(x => x)
					.Select(x => x.Count() + 1)
					.Aggregate(1, (total, next) => total * next);

				if (amountDivisors >= targetAmountDivisors)
				{
					break;
				}
			}

			return triangleNumber;
		}

		[Test]
		public void TestForExample()
		{
			long triangleNumber = FirstTriangleNumberWithAmountDivisors(5);

			Assert.AreEqual(28, triangleNumber);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(76576500, this.Solution());
		}
	}
}