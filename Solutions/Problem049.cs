namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Prime permutations.
	/// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
	/// <para>(i) each of the three terms are prime, and,</para>
	/// <para>(ii) each of the 4-digit numbers are permutations of one another.</para>
	/// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
	/// <para>What 12-digit number do you form by concatenating the three terms in this sequence?</para>
	/// </summary>
	public class Problem049 : Problem
	{
		public override long Solution()
		{
			string result = string.Empty;

			HashSet<int> primes = new HashSet<int>(Problem010.EratosthenesSieve(10000));
			foreach (int prime in primes)
			{
				if (prime < 1000)
				{
					continue;
				}

				List<string> permutations = Problem024.Permutations(prime.ToString());

				HashSet<int> permutedPrimes = new HashSet<int>();
				foreach (string permutation in permutations)
				{
					int number = int.Parse(permutation);
					if (number > 1000 && primes.Contains(number))
					{
						permutedPrimes.Add(number);
					}
				}

				int[] possiblePrimes = new int[permutedPrimes.Count];
				permutedPrimes.CopyTo(possiblePrimes);
				Array.Sort(possiblePrimes);

				for (int i = 0; i < possiblePrimes.Length - 2; i++)
				{
					int firstPrime = possiblePrimes[i];
					if (firstPrime == 1487)
					{
						continue;
					}

					for (int j = i + 1; j < possiblePrimes.Length - 1; j++)
					{
						int secondPrime = possiblePrimes[j];
						for (int k = j + 1; k < possiblePrimes.Length; k++)
						{
							int thirdPrime = possiblePrimes[k];
							if (thirdPrime - secondPrime == secondPrime - firstPrime)
							{
								result = string.Format("{0}{1}{2}", firstPrime, secondPrime, thirdPrime);
								k = j = i = possiblePrimes.Length;
							}
						}
					}
				}

				if (!string.IsNullOrEmpty(result))
				{
					break;
				}
			}

			return long.Parse(result);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(296962999629, this.Solution());
		}
	}
}