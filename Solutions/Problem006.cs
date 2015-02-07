namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;

	/// <summary>
	/// Sum square difference.
	/// The sum of the squares of the first ten natural numbers is,
	/// <para>1<sup>2</sup> + 2<sup>2</sup> + ... + 10<sup>2</sup> = 385</para>
	/// The square of the sum of the first ten natural numbers is,
	/// <para>(1 + 2 + ... + 10)<sup>2</sup> = 55<sup>2</sup> = 3025</para>
	/// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
	/// <para>Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.</para>
	/// </summary>
	public class Problem006 : Problem
	{
		public override long Solution()
		{
			return SumSquareDifference(100);
		}

		private static long SumSquareDifference(byte upperBound)
		{
			double sumOfSquares = 0;
			double squareOfSums = 0;

			byte[] values = Problem005.GetArray(1, upperBound);
			foreach (byte value in values)
			{
				sumOfSquares += Math.Pow(value, 2);
				squareOfSums += value;
			}

			squareOfSums = Math.Pow(squareOfSums, 2);
			double difference = squareOfSums - sumOfSquares;
			
			return (long)difference;
		}

		[Test]
		public void TestForExample()
		{
			long result = SumSquareDifference(10);

			Assert.AreEqual(2640, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(25164150, this.Solution());
		}
	}
}