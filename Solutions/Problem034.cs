namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Digit factorials.
	/// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
	/// <para>Find the sum of all numbers which are equal to the sum of the factorial of their digits.</para>
	/// <b>Note</b>: as 1! = 1 and 2! = 2 are not sums they are not included.
	/// </summary>
	public class Problem034 : Problem
	{
		public override long Solution()
		{
			IDictionary<long, long> factorialSums = new Dictionary<long, long>();
			
			long sum = 0;
			for(long i = 3; i <= 2540160; i++)
			{
				long number = i;
				long factorialSum = 0;
				while(number > 0)
				{
					if(factorialSums.ContainsKey(number))
					{
						factorialSum += factorialSums[number];
						break;
					}

					int digit = (int)number % 10;
					factorialSum += Factorial(digit);

					number /= 10;
				}
				
				factorialSums.Add(i, factorialSum);

				if(factorialSum == i)
				{
					sum += i;
				}
			}

			return sum;
		}

		private static long Factorial(int digit)
		{
			long factorial = 1;
			for(int i = 1; i <= digit; i++)
			{
				factorial *= i;
			}

			return factorial;
		}

		[Test]
		public void TestForExample()
		{
			Assert.AreEqual(1, Factorial(1));
			Assert.AreEqual(24, Factorial(4));
			Assert.AreEqual(120, Factorial(5));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(40730, this.Solution());
		}
	}
}