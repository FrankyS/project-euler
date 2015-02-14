﻿namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Even Fibonacci numbers.
	/// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
	/// <para>1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...</para>
	/// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
	/// </summary>
	public class Problem002 : Problem
	{
		public override long Solution()
		{
			long sum = 0;
			foreach (long fibonacci in GetFibonacci(4000000))
			{
				if(fibonacci % 2 == 0)
				{
					sum += fibonacci;
				}
			}

			return sum;
		}

		private static IEnumerable<long> GetFibonacci(long maxValue = long.MaxValue)
		{
			long first = 1;
			yield return first;

			long second = 2;
			yield return second;

			while (true)
			{
				long next = first + second;
				first = second;
				second = next;

				if (next < 0 || next > maxValue)
				{
					yield break;
				}

				yield return next;
			}
		}

		[Test]
		public void TestForExample()
		{
			byte[] expectedFibonaccis = new byte[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

			List<long> fibonaccis = new List<long>();
			foreach(long fibonacci in GetFibonacci(90))
			{
				fibonaccis.Add(fibonacci);
			}

			Assert.AreEqual(expectedFibonaccis, fibonaccis);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(4613732, this.Solution());
		}
	}
}