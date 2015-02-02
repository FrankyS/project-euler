namespace ProjectEuler.Solutions
{
	using System.Linq;
	using NUnit.Framework;

	/// <summary>
	/// Smallest multiple.
	/// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
	/// <para>What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?</para>
	/// </summary>
	public class Problem005 : Problem
	{
		public override long Solution()
		{
			return GetSmallestNumberDividable(20);
		}

		private static long GetSmallestNumberDividable(int largestDivisor)
		{
			long smallestNumber;

			int[] divisors = Enumerable.Range(1, largestDivisor).ToArray();
			for (long currentNumber = largestDivisor;; currentNumber += largestDivisor)
			{
				if (divisors.All(divisor => currentNumber % divisor == 0))
				{
					smallestNumber = currentNumber;
					break;
				}
			}

			return smallestNumber;
		}

		[Test]
		public void TestForExample()
		{
			long result = GetSmallestNumberDividable(10);

			Assert.AreEqual(2520, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(232792560, this.Solution());
		}
	}
}