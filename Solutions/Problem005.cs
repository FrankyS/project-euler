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
			return GetSmallestNumberDividableByUpTo(20);
		}

		private static long GetSmallestNumberDividableByUpTo(byte largestDivisor)
		{
			long smallestNumber;

			byte[] divisors = GetArray(1, largestDivisor);
			for (long currentNumber = largestDivisor;; currentNumber += largestDivisor)
			{
				if (AllDivisorsDividable(divisors, currentNumber))
				{
					smallestNumber = currentNumber;
					break;
				}
			}

			return smallestNumber;
		}

		private static bool AllDivisorsDividable(byte[] divisors, long currentNumber)
		{
			for(byte i = 0; i < divisors.Length; i++)
			{
				byte divisor = divisors[i];
				if(!(currentNumber % divisor == 0))
				{
					return false;
				}
			}

			return true;
		}

		public static byte[] GetArray(byte start, byte count)
		{
			byte[] divisors = new byte[count];
			for(byte i = 0; i < count; i++)
			{
				divisors[i] = start;
				start++;
			}

			return divisors;
		}

		[Test]
		public void TestForExample()
		{
			long result = GetSmallestNumberDividableByUpTo(10);

			Assert.AreEqual(2520, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(232792560, this.Solution());
		}
	}
}