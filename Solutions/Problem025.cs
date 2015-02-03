namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// 1000-digit Fibonacci number.
	/// The Fibonacci sequence is defined by the recurrence relation:
	/// <para>
	/// Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
	/// Hence the first 12 terms will be:
	/// </para>
	/// 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
	/// <para>
	/// The 12th term, 144, is the first term to contain three digits.
	/// </para>
	/// What is the first term in the Fibonacci sequence to contain 1000 digits?
	/// </summary>
	public class Problem025 : Problem
	{
		public override long Solution()
		{
			long counter = 1;
			foreach(int[] fibonacci in MathHelper.GetFibonacciAsArray())
			{
				counter++;
				if(fibonacci.Length >= 1000)
				{
					break;
				}
			}

			return counter;
		}

		[Test]
		public void TestForExample()
		{
			int[] expectedDigits = new int[] { 1, 4, 4 };

			int counter = 1;
			int[] digits = new int[0];
			foreach(int[] fibonacci in MathHelper.GetFibonacciAsArray())
			{
				counter++;
				if(counter == 12)
				{
					digits = fibonacci;
					break;
				}
			}

			Assert.AreEqual(expectedDigits, digits);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(4782, this.Solution());
		}
	}
}