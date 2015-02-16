namespace ProjectEuler.Solutions
{
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
			int number = 20;
			while (number % 20 != 0 || number % 19 != 0 || number % 18 != 0 || number % 17 != 0 || number % 16 != 0 ||
				number % 15 != 0 || number % 14 != 0 || number % 13 != 0 || number % 12 != 0 || number % 11 != 0)
			{
				number += 20;
			}

			return number;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(232792560, this.Solution());
		}
	}
}