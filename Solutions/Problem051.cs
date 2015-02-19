namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Prime digit replacements.
	/// By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
	/// <para>
	/// By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, 
	/// yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.
	/// </para>
	/// Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.
	/// </summary>
	public class Problem051 : Problem
	{
		public override long Solution()
		{
			long smallestPrime = 0;
			HashSet<int> primes = new HashSet<int>(Primes.EratosthenesSieve(1000000));

			foreach (int number in primes)
			{
				if (number < 10000)
				{
					continue;
				}

				string numberString = number.ToString();
				foreach (char digit in numberString)
				{
					List<int> replacedNumbers = new List<int>();
					string numberMask = numberString.Replace(digit, '*');
					for (char newDigit = '0'; newDigit <= '9'; newDigit++)
					{
						string replacedNumberString = numberMask.Replace('*', newDigit);
						if (replacedNumberString[0] != '0')
						{
							int replacedNumber = int.Parse(replacedNumberString);
							if (primes.Contains(replacedNumber))
							{
								replacedNumbers.Add(replacedNumber);
							}
						}
					}

					if (replacedNumbers.Count == 8)
					{
						int[] targetPrimes = new int[replacedNumbers.Count];
						replacedNumbers.CopyTo(targetPrimes);
						Array.Sort(targetPrimes);

						Console.WriteLine(replacedNumbers.Count + " - " + string.Join(", ", replacedNumbers));
						smallestPrime = targetPrimes[0];
						break;
					}
				}

				if (smallestPrime > 0)
				{
					break;
				}
			}

			return smallestPrime;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(121313, this.Solution());
		}
	}
}