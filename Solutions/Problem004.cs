namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Largest palindrome product.
	/// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
	/// <para>Find the largest palindrome made from the product of two 3-digit numbers.</para>
	/// </summary>
	public class Problem004 : Problem
	{
		public override long Solution()
		{
			return GetLargestPalindrome(100, 999);
		}

		private static long GetLargestPalindrome(int lowerBound, int upperBound)
		{
			long largestPalindrome = 0;
			for (int x = lowerBound; x <= upperBound; x++)
			{
				for (int y = lowerBound; y <= upperBound; y++)
				{
					long product = x * y;
					if (IsPalindrome(product) && product > largestPalindrome)
					{
						largestPalindrome = product;
					}
				}
			}

			return largestPalindrome;
		}

		private static bool IsPalindrome(long number)
		{
			bool isPalindrome = true;

			string numberString = number.ToString();
			int length = numberString.Length;
			for (int i = 0; i < length / 2; i++)
			{
				if (numberString[i] != numberString[length - 1 - i])
				{
					isPalindrome = false;
					break;
				}
			}

			return isPalindrome;
		}

		[Test]
		public void TestForExample()
		{
			long result = GetLargestPalindrome(10, 99);

			Assert.AreEqual(9009, result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(906609, this.Solution());
		}
	}
}