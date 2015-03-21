namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Lychrel numbers.
	/// If we take 47, reverse and add, 47 + 74 = 121, which is palindromic.
	/// <para>Not all numbers produce palindromes so quickly. For example,</para>
	/// <para>349 + 943 = 1292,</para>
	/// <para>1292 + 2921 = 4213</para>
	/// <para>4213 + 3124 = 7337</para>
	/// That is, 349 took three iterations to arrive at a palindrome.
	/// <para>
	/// Although no one has proved it yet, it is thought that some numbers, like 196, never produce a palindrome. 
	/// A number that never forms a palindrome through the reverse and add process is called a Lychrel number. 
	/// Due to the theoretical nature of these numbers, and for the purpose of this problem, we shall assume that a number is Lychrel until proven otherwise. 
	/// In addition you are given that for every number below ten-thousand, it will either 
	/// (i) become a palindrome in less than fifty iterations, or, 
	/// (ii) no one, with all the computing power that exists, has managed so far to map it to a palindrome. 
	/// In fact, 10677 is the first number to be shown to require over fifty iterations before producing a palindrome: 4668731596684224866951378664 (53 iterations, 28-digits).
	/// </para>
	/// Surprisingly, there are palindromic numbers that are themselves Lychrel numbers; the first example is 4994.
	/// <para>How many Lychrel numbers are there below ten-thousand?</para>
	/// <b>NOTE:</b> Wording was modified slightly on 24 April 2007 to emphasise the theoretical nature of Lychrel numbers.
	/// </summary>
	public class Problem055 : Problem
	{
		public override long Solution()
		{
			long amountLychrelNumbers = 0;
			for (int i = 10; i < 10000; i++)
			{
				if (IsLychrelNumber(i))
				{
					amountLychrelNumbers++;
				}
			}
			
			return amountLychrelNumbers;
		}

		private static bool IsLychrelNumber(long number, int iteration = 0)
		{
			bool isLychrelNumber = false;
			if (iteration <= 50)
			{
				if (iteration == 0 || !Problem004.IsPalindrome(number))
				{
					long reverse = Reverse(number);
					isLychrelNumber = IsLychrelNumber(number + reverse, iteration + 1);
				}
			}
			else
			{
				isLychrelNumber = true;
			}

			return isLychrelNumber;
		}

		private static long Reverse(long number)
		{
			long reverse = 0;
			while (number > 0)
			{
				long remainder = number % 10;
				reverse = (reverse * 10) + remainder;
				number = number / 10;
			}

			return reverse;
		}

		[TestCase(47)]
		[TestCase(349)]
		public void TestForProblem(long number)
		{
			bool isLychrelNumber = IsLychrelNumber(number);

			Assert.IsFalse(isLychrelNumber);
		}

		[Test]
		public void TestForSolution()
		{
			Assert.AreEqual(249, this.Solution());
		}
	}
}