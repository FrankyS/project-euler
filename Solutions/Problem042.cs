namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;
	using ProjectEuler.Input;

	/// <summary>
	/// Coded triangle numbers.
	/// The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:
	/// <para>1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...</para>
	/// By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value.
	/// For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.
	/// <para>Using Problem042.txt, a 16K text file containing nearly two-thousand common English words, how many are triangle words?</para>
	/// </summary>
	public class Problem042 : Problem
	{
		public override long Solution()
		{
			long count = 0;
			string[] words = Input.Problem042.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].Trim('\"');
			}

			foreach (string word in words)
			{
				long value = Problem022.GetStringValue(word);
				if (IsTriangleNumber(value))
				{
					count++;
				}
			}

			return count;
		}

		private static bool IsTriangleNumber(long wordValue)
		{
			int number = 0;
			for (int i = 1; i <= wordValue; i++)
			{
				number += i;
				if(number >= wordValue)
				{
					break;
				}
			}
				
			return number == wordValue;
		}

		[Test]
		public void TestForExample()
		{
			Assert.AreEqual(55, Problem022.GetStringValue("SKY"));
			Assert.IsTrue(IsTriangleNumber(55));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(162, this.Solution());
		}
	}
}