namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Circular primes.
	/// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
	/// <para>There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.</para>
	///  How many circular primes are there below one million?
	/// </summary>
	public class Problem035 : Problem
	{
		public override long Solution()
		{
			return GetCircularPrimes(1000000).Count;
		}

		private static ICollection<int> GetCircularPrimes(int upperBound)
		{
			ICollection<int> primes = new HashSet<int>(Problem010.EratosthenesSieve(upperBound));

			ICollection<int> circularPrimes = new HashSet<int>();
			foreach (int primeNumber in primes)
			{
				// Skip numbers that have already been added as a rotation
				if (!circularPrimes.Contains(primeNumber))
				{
					// Skip all numbers containing an even digit
					string primeString = primeNumber.ToString();
					if(primeNumber > 2)
					{
						bool canContinue = false;
						foreach(char digit in primeString)
						{
							if(digit % 2 == 0)
							{
								canContinue = true;
								break;
							}
						}

						if(canContinue)
						{
							continue;
						}
					}

					List<int> numbers = new List<int> { primeNumber };
					int rotatedNumber = primeNumber;
					for(int i = 1; i < primeString.Length; i++)
					{
						rotatedNumber = RotateNumber(rotatedNumber);
						if (!primes.Contains(rotatedNumber))
						{
							numbers.Clear();
							break;
						}
						numbers.Add(rotatedNumber);
					}

					// Add the number and all its rotations
					foreach (int number in numbers)
					{
						circularPrimes.Add(number);
					}
				}
			}

			return circularPrimes;
		}

		private static int RotateNumber(int number)
		{
			int rotatedNumber = 0;

			int multiplier = 10;
			while(number > 0)
			{
				if(number < 10)
				{
					rotatedNumber += number;
				}
				else
				{
					int digit = number % 10;
					rotatedNumber += digit * multiplier;
					multiplier *= 10;
				}

				number /= 10;
			}
			
			return rotatedNumber;
		}

		[Test]
		public void TestForRotateNumber()
		{
			Assert.AreEqual(971, RotateNumber(197));
			Assert.AreEqual(719, RotateNumber(971));
		}

		[Test]
		public void TestForExampe()
		{
			int[] expectedPrimes = new int[] { 2, 3, 5, 7, 11, 13, 31, 17, 71, 37, 73, 79, 97 };

			ICollection<int> circularPrimes = GetCircularPrimes(100);

			Assert.AreEqual(expectedPrimes, circularPrimes);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(55, this.Solution());
		}
	}
}