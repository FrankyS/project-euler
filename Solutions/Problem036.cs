namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Double-base palindromes.
	/// The decimal number, 585 = 1001001001<sub>2</sub> (binary), is palindromic in both bases.
	/// <para>Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.</para>
	/// (Please note that the palindromic number, in either base, may not include leading zeros.)
	/// </summary>
	public class Problem036 : Problem
	{
		public override long Solution()
		{
			long sum = 0;
			for (int number = 1; number < 1000000; number++)
			{
				if(Problem004.IsPalindrome(number))
				{
					IList<byte> binary = ToBinary(number);
					if(IsPalindrome(binary))
					{
						sum += number;
					}
				}
			}

			return sum;
		}

		private static IList<byte> ToBinary(long number)
		{
			IList<byte> bytes = new List<byte>();
			while(number > 0)
			{
				if (number % 2 == 0)
				{
					bytes.Insert(0, 0);
				}
				else
				{
					bytes.Insert(0, 1);
				}

				number /= 2;
			}

			return bytes;
		}

		private static bool IsPalindrome(IList<byte> number)
		{
			bool isPalindrome = true;

			int length = number.Count;
			for (int i = 0; i < length / 2; i++)
			{
				if (number[i] != number[length - 1 - i])
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
			byte[] expectedBinary = new byte[] { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
			IList<byte> binary = ToBinary(585);

			Assert.AreEqual(expectedBinary, binary);
			Assert.IsTrue(IsPalindrome(binary));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(872187, this.Solution());
		}
	}
}