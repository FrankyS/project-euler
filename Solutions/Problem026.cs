namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Reciprocal cycles.
	/// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
	/// <para>1/2 = 0.5</para>
	/// <para>1/3 = 0.(3)</para>
	/// <para>1/4 = 0.25</para>
	/// <para>1/5 = 0.2</para>
	/// <para>1/6 = 0.1(6)</para>
	/// <para>1/7 = 0.(142857)</para>
	/// <para>1/8 = 0.125</para>
	/// <para>1/9 = 0.(1)</para>
	/// <para>1/10 = 0.1</para>
	/// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
	/// <para>Find the value of d &lt; 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.</para>
	/// </summary>
	public class Problem026 : Problem
	{
		public override long Solution()
		{
			int numberWithLongestCycle = 0;
			int longestCycle = 0;
			for (int i = 2; i < 1000; i++)
			{
				string recurringCycle = DivideDigits(new List<string>(), 1, i);
				if (recurringCycle.Length > longestCycle)
				{
					numberWithLongestCycle = i;
					longestCycle = recurringCycle.Length;
				}
			}

			return numberWithLongestCycle;
		}

		private static string EulerDivide(int numerator, int divisor)
		{
			List<string> decimalPlaces = new List<string>();
			string recurringCycle = DivideDigits(decimalPlaces, numerator, divisor);

			string result = string.Join(string.Empty, decimalPlaces);
			if (!string.IsNullOrEmpty(recurringCycle))
			{
				result += string.Format("({0})", recurringCycle);
			}

			return result;
		}

		private static string DivideDigits(IList<string> decimalPlaces, int numerator, int divisor)
		{
			string recurringCycle = string.Empty;
			Dictionary<int, int> remaindersWithIndex = new Dictionary<int, int>();

			int index = 0;
			while (numerator > 0)
			{
				int decimalPlace = numerator / divisor;

				int remainder = (numerator % divisor) * 10;
				if (remaindersWithIndex.ContainsKey(remainder))
				{
					int recurringStart = remaindersWithIndex[remainder];
					if (recurringStart + 1 < index)
					{
						decimalPlaces.Add(decimalPlace.ToString());
					}

					for (int i = recurringStart; i < decimalPlaces.Count;)
					{
						recurringCycle += decimalPlaces[i];
						decimalPlaces.RemoveAt(i);
					}
 
					break;
				}

				remaindersWithIndex.Add(numerator, index);
				index++;

				decimalPlaces.Add(decimalPlace.ToString());
				if (numerator < divisor)
				{
					decimalPlaces.Add(".");
					index++;
				}

				numerator = remainder;
			}

			return recurringCycle;
		}

		[TestCase(2, "0.5")]
		[TestCase(3, "0.(3)")]
		[TestCase(4, "0.25")]
		[TestCase(5, "0.2")]
		[TestCase(6, "0.1(6)")]
		[TestCase(7, "0.(142857)")]
		[TestCase(8, "0.125")]
		[TestCase(9, "0.(1)")]
		[TestCase(10, "0.1")]
		public void TestForExample(int divisor, string expectedResult)
		{
			string result = EulerDivide(1, divisor);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void TestForProblem() 
		{
			Assert.AreEqual(983, this.Solution());
		}
	}
}