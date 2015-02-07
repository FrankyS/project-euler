namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

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
			foreach (byte[] fibonacci in GetFibonacciAsArray())
			{
				counter++;
				if(fibonacci.Length >= 1000)
				{
					break;
				}
			}

			return counter;
		}

		public static IEnumerable<byte[]> GetFibonacciAsArray()
		{
			byte[] first = new byte[] { 1 };
			yield return first;

			byte[] second = new byte[] { 2 };
			yield return second;

			while (true)
			{
				byte[] next = Problem013.Sum(first, second);
				first = second;
				second = next;

				if (next.Length > int.MaxValue)
				{
					yield break;
				}

				yield return next;
			}
		}

		[Test]
		public void TestForExample()
		{
			byte[] expectedDigits = new byte[] { 1, 4, 4 };

			int counter = 1;
			byte[] digits = new byte[0];
			foreach (byte[] fibonacci in GetFibonacciAsArray())
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