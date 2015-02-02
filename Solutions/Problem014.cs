namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Longest Collatz sequence.
	/// The following iterative sequence is defined for the set of positive integers:
	/// <para>n → n/2 (n is even)</para>
	/// <para>n → 3n + 1 (n is odd)</para>
	/// Using the rule above and starting with 13, we generate the following sequence:
	/// <para>13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1</para>
	/// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
	/// <para>Which starting number, under one million, produces the longest chain?</para>
	/// <b>NOTE:</b> Once the chain starts the terms are allowed to go above one million.
	/// </summary>
	public class Problem014 : Problem
	{
		public override long Solution()
		{
			int startingNumber = 0;
			int longestChain = 0;
			for(int i = 1; i < 1000000; i++)
			{
				int chainLength = GetCollatzSequence(i).Count;
				if(chainLength > longestChain)
				{
					longestChain = chainLength;
					startingNumber = i;
				}
			}

			return startingNumber;
		}

		private static IList<long> GetCollatzSequence(long start)
		{
			List<long> sequence = new List<long>
				{
					start
				};

			long number = start;
			while (number > 1)
			{
				if (number % 2 == 0)
				{
					number = number / 2;
				}
				else
				{
					number = (number * 3) + 1;
				}

				sequence.Add(number);
			}

			return sequence;
		}

		[Test]
		public void TestForExample()
		{
			long[] expectedSequence = new long[] { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };
			IEnumerable<long> collatzSequence = GetCollatzSequence(13);

			Assert.AreEqual(expectedSequence, collatzSequence);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(837799, this.Solution());
		}
	}
}