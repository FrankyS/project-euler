namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Champernowne's constant.
	/// An irrational decimal fraction is created by concatenating the positive integers:
	/// <para>0.12345678910<b>1</b>112131415161718192021...</para>
	/// It can be seen that the 12th digit of the fractional part is 1.
	/// <para>If dn represents the nth digit of the fractional part, find the value of the following expression.</para>
	/// d<sub>1</sub> × d<sub>10</sub> × d<sub>100</sub> × d<sub>1000</sub> × d<sub>10000</sub> × d<sub>100000</sub> × d<sub>1000000</sub>
	/// </summary>
	public class Problem040 : Problem
	{
		public override long Solution()
		{
			long solution = 1;

			long amountDigits = 0;
			int nextRelevantDigit = 1;
			for (int i = 1;; i++)
			{
				string number = i.ToString();
				foreach (char digit in number)
				{
					amountDigits++;
					if (amountDigits == nextRelevantDigit)
					{
						solution *= digit - 48;
						nextRelevantDigit *= 10;
					}
				}

				if (nextRelevantDigit >= 10000000)
				{
					break;
				}
			}

			return solution;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(210, this.Solution());
		}
	}
}