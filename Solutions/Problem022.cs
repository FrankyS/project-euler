namespace ProjectEuler.Solutions
{
	using System;
	using NUnit.Framework;
	using ProjectEuler.Helper;
	using ProjectEuler.Input;

	/// <summary>
	/// Names scores.
	/// Using Problem022.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
	/// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
	/// <para>
	/// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
	/// So, COLIN would obtain a score of 938 × 53 = 49714.
	/// </para>
	/// What is the total of all the name scores in the file?
	/// </summary>
	public class Problem022 : Problem
	{
		public override long Solution()
		{
			long totalNameScore = 0;
			string[] names = SplitAndSortNames(Input.Problem022);
			for (int i = 0; i < names.Length; i++)
			{
				long nameValue = Numbers.GetStringValue(names[i]);
				totalNameScore += nameValue * (i + 1);
			}

			return totalNameScore;
		}

		private static string[] SplitAndSortNames(string input)
		{
			string[] separator = { "," };
			string[] names = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			for(int i = 0; i < names.Length; i++)
			{
				names[i] = names[i].Trim('\"');
			}
			Array.Sort(names);

			return names;
		}

		[Test]
		public void NameColinHasValueOf53() 
		{
			long value = Numbers.GetStringValue("COLIN");
	
			Assert.AreEqual(53, value);
		}

		[Test]
		public void ColinIsAtPos938AfterSort()
		{
			// Act
			string[] names = SplitAndSortNames(Input.Problem022);

			// Assert
			Assert.AreEqual("COLIN", names[937]);
		}

		[Test]
		public void TestForProblem() 
		{
			Assert.AreEqual(871198282, this.Solution());
		}
	}
}