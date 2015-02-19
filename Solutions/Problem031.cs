namespace ProjectEuler.Solutions
{
	using System.Collections.Generic;
	using NUnit.Framework;

	/// <summary>
	/// Coin sums.
	/// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
	/// <para>1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).</para>
	/// It is possible to make £2 in the following way:
	/// <para>1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p</para>
	/// How many different ways can £2 be made using any number of coins?
	/// </summary>
	public class Problem031 : Problem
	{
		public override long Solution()
		{
			int[] coins = new[] { 200, 100, 50, 20, 10, 5, 2, 1 };
			return GetCombinations(coins, 200).Count;
		}

		private static List<List<int>> GetCombinations(int[] coins, int targetValue, int initialSum = 0, int startIndex = 0)
		{
			List<List<int>> totalCombinations = new List<List<int>>();

			for(int i = startIndex; i < coins.Length; i++)
			{
				int currentCoin = coins[i];
				int currentSum = initialSum + currentCoin;

				if(currentSum < targetValue)
				{
					List<List<int>> combinations = GetCombinations(coins, targetValue, currentSum, i);
					foreach (List<int> combination in combinations)
					{
						combination.Insert(0, currentCoin);
						totalCombinations.Add(combination);
					}

					continue;
				}

				if(currentSum == targetValue)
				{
					List<int> currentCombination = new List<int> { currentCoin };
					totalCombinations.Add(currentCombination);
				}
			}

			return totalCombinations;
		}

		private static string WriteCombination(List<int> coins)
		{
			List<string> resultParts = new List<string>();

			int amountCurrentCoins = 1;
			int currentCoin = coins[0];
			for(int i = 1; i < coins.Count; i++)
			{
				if(coins[i] == currentCoin)
				{
					amountCurrentCoins++;
				}
				else
				{
					resultParts.Add(amountCurrentCoins + " x " + currentCoin);
					currentCoin = coins[i];
					amountCurrentCoins = 1;
				}
			}

			resultParts.Add(amountCurrentCoins + " x " + currentCoin);
			
			return string.Join(" + ", resultParts);
		}

		[Test]
		public void TestForUpToFivePence()
		{
			int[] coins = new[] { 5, 2, 1 };
			List<List<int>> combinations = GetCombinations(coins, 5);

			Assert.AreEqual(4, combinations.Count);
			Assert.AreEqual("1 x 5", WriteCombination(combinations[0]));
			Assert.AreEqual("2 x 2 + 1 x 1", WriteCombination(combinations[1]));
			Assert.AreEqual("1 x 2 + 3 x 1", WriteCombination(combinations[2]));
			Assert.AreEqual("5 x 1", WriteCombination(combinations[3]));
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(73682, this.Solution());
		}
	}
}