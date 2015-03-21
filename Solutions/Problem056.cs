namespace ProjectEuler.Solutions
{
	using System.Numerics;
	using NUnit.Framework;
	
	/// <summary>
	/// Powerful digit sum.
	/// A googol (10<sup>100</sup>) is a massive number: one followed by one-hundred zeros; 100<sup>100</sup> is almost unimaginably large: one followed by two-hundred zeros. 
	/// Despite their size, the sum of the digits in each number is only 1.
	/// <para>Considering natural numbers of the form, a<sup>b</sup>, where a, b &lt; 100, what is the maximum digital sum?</para>
	/// </summary>
	public class Problem056 : Problem
	{
		public override long Solution()
		{
			long maximumDigitalSum = 0;
			for (int a = 0; a < 100; a++)
			{
				for (int b = 0; b < 100; b++)
				{
					BigInteger currentDigitalSum = 0;
					BigInteger power = BigInteger.Pow(a, b);
					while (power > 0)
					{
						currentDigitalSum += power % 10;
						power /= 10;
					}

					if (currentDigitalSum > maximumDigitalSum)
					{
						maximumDigitalSum = (long)currentDigitalSum;
					}
				}
			}
			
			return maximumDigitalSum;
		}
		
		[Test]
		public void TestForSolution()
		{
			Assert.AreEqual(972, this.Solution());
		}
	}
}