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
			IDictionary<long, int> alreadyProcessed = new Dictionary<long, int>();

			int startingNumber = 0;
			int longestChain = 0;
			for(int i = 2; i < 1000000; i++)
			{
				if(!alreadyProcessed.ContainsKey(i))
				{
					int chainLength = GetCollatzLength(i, alreadyProcessed);
					if(chainLength > longestChain)
					{
						longestChain = chainLength;
						startingNumber = i;
					}
				}
			}

			return startingNumber;
		}

		private static int GetCollatzLength(int start, IDictionary<long, int> alreadyProcessed)
		{
			int offset = 0;
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

				if(alreadyProcessed.ContainsKey(number))
				{
					offset = alreadyProcessed[number];
					break;
				}

				sequence.Add(number);
			}

			int length = sequence.Count;
			for(int i = 0; i < length; i++)
			{
				long value = sequence[i];
				alreadyProcessed.Add(value, length - i + offset);
			}

			return length + offset;
		}

		[Test]
		public void TestForExample()
		{
			int[] expectedSequence = new int[] { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };
			long collatzLength = GetCollatzLength(13, new Dictionary<long, int>());

			Assert.AreEqual(expectedSequence.Length, collatzLength);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(837799, this.Solution());
		}
	}
}