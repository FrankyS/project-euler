namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	/// <summary>
	/// Number letter counts.
	/// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
	/// <para>If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?</para>
	/// <b>NOTE:</b> Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
	/// The use of "and" when writing out numbers is in compliance with British usage.
	/// </summary>
	public class Problem017 : Problem
	{
		#region Numbers Dictionary
		private static readonly Dictionary<int, string> writtenNumbers = new Dictionary<int, string>
				{
					{ 1000, "thousand" }, 
					{ 100, "hundred" }, 
					{ 90, "ninety" }, 
					{ 80, "eighty" }, 
					{ 70, "seventy" }, 
					{ 60, "sixty" }, 
					{ 50, "fifty" }, 
					{ 40, "forty" }, 
					{ 30, "thirty" }, 
					{ 20, "twenty" }, 
					{ 19, "nineteen" }, 
					{ 18, "eighteen" }, 
					{ 17, "seventeen" }, 
					{ 16, "sixteen" }, 
					{ 15, "fifteen" }, 
					{ 14, "fourteen" }, 
					{ 13, "thirteen" }, 
					{ 12, "twelve" }, 
					{ 11, "eleven" }, 
					{ 10, "ten" }, 
					{ 9, "nine" }, 
					{ 8, "eight" }, 
					{ 7, "seven" }, 
					{ 6, "six" }, 
					{ 5, "five" }, 
					{ 4, "four" }, 
					{ 3, "three" }, 
					{ 2, "two" }, 
					{ 1, "one" }, 
				};
		# endregion

		public override long Solution()
		{
			long totalLength = 0;
			for(int i = 1; i <= 1000; i++)
			{
				string text = ConvertToBritishEnglish(i);
				totalLength += text.Replace(" ", string.Empty).Replace("-", string.Empty).Length;
			}

			return totalLength;
		}

		private static string ConvertToBritishEnglish(int number)
		{
			int[] keys = writtenNumbers.Keys.ToArray();
			
			string text = string.Empty;
			string separator = string.Empty;

			foreach (int key in keys)
			{
				if (number / key > 0)
				{
					int amount = number / key;
					if (key >= 100)
					{
						text += writtenNumbers[amount] + " " + writtenNumbers[key];
						separator = " and ";
					}
					else if (key >= 20)
					{
						text += separator + writtenNumbers[key];
						separator = "-";
					}
					else
					{
						text += separator + writtenNumbers[key];
					}

					number = number % (amount * key);
				}
			}

			return text;
		}

		[TestCase(342, "three hundred and forty-two")]
		[TestCase(115, "one hundred and fifteen")]
		public void TestForExample(int number, string expectedText)
		{
			string text = ConvertToBritishEnglish(number);

			Assert.AreEqual(expectedText, text);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(21124, this.Solution());
		}
	}
}