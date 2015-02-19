namespace ProjectEuler.Solutions
{
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Factorial digit sum.
	/// n! means n × (n − 1) × ... × 3 × 2 × 1
	/// <para>
	/// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
	/// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
	/// </para>
	/// Find the sum of the digits in the number 100!
	/// </summary>
	public class Problem020 : Problem
	{
		public override long Solution()
		{
			int[] factorial = Factorial(100);
			long sum = 0;
			foreach(byte digit in factorial)
			{
				sum += digit;
			}

			return sum;
		}

		private static int[] Factorial(int number)
		{
			int[] factorial = { 1 };
			for (int i = 1; i <= number; i++)
			{
				factorial = Multiply(factorial, ArrayMath.ToDigitsArray(i.ToString()));
			}

			return factorial;
		}

		private static int[] Multiply(int[] first, int[] second)
		{
			int count = first.Length + second.Length;
			int[] result = new int[0];
			for (int f = first.Length - 1; f >= 0; f--)
			{
				for (int s = second.Length - 1; s >= 0; s--)
				{
					int[] tmpResult = new int[count];
					int targetIndex = (f + s) + 1;
					int value = first[f] * second[s];
					tmpResult[targetIndex] = value % 10;
					while ((value /= 10) > 0)
					{
						targetIndex--;
						tmpResult[targetIndex] = value % 10;
					}

					result = ArrayMath.Sum(result, tmpResult);
				}
			}

			int startIndex = 0;
			while(result[startIndex] == 0)
			{
				startIndex++;
			}

			int[] cleanedResult = new int[result.Length - startIndex];
			for(int i = 0; i < cleanedResult.Length; i++)
			{
				cleanedResult[i] = result[i + startIndex];
			}

			return cleanedResult;
		}

		[TestCase("11", "12", "132")]
		[TestCase("5", "12", "60")]
		[TestCase("15", "3", "45")]
		public void TestForMultiply(string first, string second, string expectedResult)
		{
			int[] result = Multiply(ArrayMath.ToDigitsArray(first), ArrayMath.ToDigitsArray(second));

			Assert.AreEqual(expectedResult, string.Join(string.Empty, result));
		}

		[Test]
		public void TestForExample()
		{
			int[] expectedFactorial = new int[] { 3, 6, 2, 8, 8, 0, 0 };
			int[] factorial = Factorial(10);

			Assert.AreEqual(expectedFactorial, factorial);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(648, this.Solution());
		}
	}
}