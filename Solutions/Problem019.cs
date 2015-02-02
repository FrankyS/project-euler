namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Counting Sundays.
	/// You are given the following information, but you may prefer to do some research for yourself.
	/// <list type="bullet">
	/// <item>1 Jan 1900 was a Monday.</item>
	/// <item>
	/// Thirty days has September, April, June and November. 
	/// All the rest have thirty-one, Saving February alone, Which has twenty-eight, rain or shine. 
	/// And on leap years, twenty-nine.
	/// </item>
	/// <item>A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.</item>
	/// </list>
	/// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
	/// </summary>
	public class Problem019 : Problem
	{
		public override long Solution()
		{
			int amountSundays = 0;
			long days = 365; // skip the first year
			Dictionary<int, int> daysPerMonth = new Dictionary<int, int>
				{
					{ 1, 31 }, { 2, 28 }, { 3, 31 }, { 4, 30 }, { 5, 31 }, { 6, 30 }, { 7, 31 }, { 8, 31 }, { 9, 30 }, { 10, 31 }, { 11, 30 }, { 12, 31 }, 
				};

			for (int year = 1901; year < 2001; year++)
			{
				for (int month = 1; month <= 12; month++)
				{
					if (days % 7 == 6)
					{
						amountSundays++;
					}

					days += daysPerMonth[month];
					if (month == 2 && DateTimeHelper.IsLeapYear(year))
					{
						days++;
					}
				}
			}

			return amountSundays;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(171, this.Solution());
		}
	}
}