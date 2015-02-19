namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;

	/// <summary>
	/// Permuted multiples.
	/// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
	/// <para>Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.</para>
	/// </summary>
	public class Problem052 : Problem
	{
		public override long Solution()
		{
			long smallest;
			for (int baseNumber = 1;; baseNumber++)
			{
				bool isPermutedMultiple = true;

				string baseNumberString = baseNumber.ToString();
				for (int factor = 6; factor > 1; factor--)
				{
					int numberToCheck = baseNumber * factor;
					if (!IsPermutation(baseNumberString, numberToCheck.ToString()))
					{
						isPermutedMultiple = false;
						break;
					}
				}

				if (isPermutedMultiple)
				{
					smallest = baseNumber;
					break;
				}
			}
			
			return smallest;
		}

		private static bool IsPermutation(string baseNumber, string numberToCheck)
		{
			bool isPermutation = true;
			if (baseNumber.Length != numberToCheck.Length)
			{
				isPermutation = false;
			}
			else
			{
				char[] baseArray = baseNumber.ToCharArray();
				char[] checkArray = numberToCheck.ToCharArray();

				Array.Sort(baseArray);
				Array.Sort(checkArray);
				for (int i = 0; i < baseArray.Length; i++)
				{
					if (baseArray[i] != checkArray[i])
					{
						isPermutation = false;
						break;
					}
				}
			}

			return isPermutation;
		}

		[Test]
		public void TestForIsPermutation()
		{
			Assert.IsTrue(IsPermutation("125874", "251748"));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(142857, this.Solution());
		}
	}
}