namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Input;

	/// <summary>
	/// Poker hands.
	/// In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:
	/// <para>High Card: Highest value card.</para>
	/// <para>One Pair: Two cards of the same value.</para>
	/// <para>Two Pairs: Two different pairs.</para>
	/// <para>Three of a Kind: Three cards of the same value.</para>
	/// <para>Straight: All cards are consecutive values.</para>
	/// <para>Flush: All cards of the same suit.</para>
	/// <para>Full House: Three of a kind and a pair.</para>
	/// <para>Four of a Kind: Four cards of the same value.</para>
	/// <para>Straight Flush: All cards are consecutive values of same suit.</para>
	/// <para>Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.</para>
	/// The cards are valued in the order:
	/// <para>2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.</para>
	/// <para>
	/// If two players have the same ranked hands then the rank made up of the highest value wins; for example, a pair of eights beats a pair of fives (see example 1 below).
	/// But if two ranks tie, for example, both players have a pair of queens, then highest cards in each hand are compared (see example 4 below); 
	/// if the highest cards tie then the next highest cards are compared, and so on.
	/// </para>
	/// Consider the following five hands dealt to two players:
	/// <table>
	///	<th><td>Hand</td><td>Player 1</td><td>Player 2</td><td>Winner</td></th>
	/// 	<tr><td>1</td><td>5H 5C 6S 7S KD (Pair of Fives)</td><td>2C 3S 8S 8D TD (Pair of Eights)</td><td>Player 2</td></tr>
	/// 	<tr><td>2</td><td>5D 8C 9S JS AC (Highest card Ace)</td><td>2C 5C 7D 8S QH (Highest card Queen)</td><td>Player 1</td></tr>
	/// 	<tr><td>3</td><td>2D 9C AS AH AC (Three Aces)</td><td>3D 6D 7D TD QD (Flush with Diamonds)</td><td>Player 2</td></tr>
	/// 	<tr><td>4</td><td>4D 6S 9H QH QC (Pair of Queens, highest card Nine)</td><td>3D 6D 7H QD QS (Pair of Queens, highest card Seven)</td><td>Player 1</td></tr>
	/// 	<tr><td>5</td><td>2H 2D 4C 4D 4S (Full House, with Three Fours)</td><td>3C 3D 3S 9S 9D (Full House, with Three Threes)</td><td>Player 1</td></tr>
	/// </table>
	/// <para>
	/// The file, Problem054.txt, contains one-thousand random hands dealt to two players. Each line of the file contains ten cards (separated by a single space): 
	/// the first five are Player 1's cards and the last five are Player 2's cards. You can assume that all hands are valid (no invalid characters or repeated cards), 
	/// each player's hand is in no specific order, and in each hand there is a clear winner.
	/// </para>
	/// How many hands does Player 1 win?
	/// </summary>
	public class Problem054 : Problem
	{
		public override long Solution()
		{
			long playerOneWins = 0;
			string[] matches = Input.Problem054.Split(new char[] { '\n' });
			foreach (string match in matches)
			{
				PokerHand playerOne = new PokerHand(match.Substring(0, 14));
				PokerHand playerTwo = new PokerHand(match.Substring(15));
				if (playerOne.CompareTo(playerTwo) > 0)
				{
					playerOneWins++;
				}
			}

			return playerOneWins;
		}

		private class PokerHand : IComparable
		{
			private static readonly int[] handOffsets = new[]
				{
					0, // high card
					15, // one pair
					30, // two pair
					45, // three of a kind
					55, // straight
					75, // flush
					90, // full house
					105, // four of a kind
					120, // straight flush
					150 // royal flush
				};
			
			private readonly Card[] cards = new Card[5];

			public PokerHand(string hand)
			{
				string[] cardStrings = hand.Split(' ');

				Card[] tmpCards = new Card[5];
				for (int i = 0; i < 5; i++)
				{
					tmpCards[i] = new Card(cardStrings[i]);
				}

				Array.Sort(tmpCards);
				this.cards = tmpCards;
			}

			public int Value
			{
				get { return this.CalculateValue(); }
			}

			private int CalculateValue()
			{
				int calcValue = this.cards[0].Value;

				bool isStraight = true;
				bool isFlush = true;

				IDictionary<int, int> occurences = new Dictionary<int, int>();
				for (int i = 0; i < 5; i++)
				{
					Card currentCard = this.cards[i];
					if (i > 0)
					{
						Card previousCard = this.cards[i - 1];
						if (previousCard.Value - currentCard.Value != 1)
						{
							isStraight = false;
						}

						if (currentCard.Color != previousCard.Color)
						{
							isFlush = false;
						}
					}

					if (!occurences.ContainsKey(currentCard.Value))
					{
						occurences.Add(currentCard.Value, 1);
					}
					else
					{
						occurences[currentCard.Value]++;
					}
				}

				int offset = 0;

				// Must consider pairs, if less than 5 occurences exists
				if (occurences.Count != 5)
				{
					int amountPairs = 0;
					int maxPairLength = 0;
					int highestPairValue = 0;
					foreach (KeyValuePair<int, int> occurence in occurences)
					{
						if (occurence.Value > 1)
						{
							if (occurence.Value == 3 || occurence.Key > highestPairValue)
							{
								highestPairValue = occurence.Key;
							}

							if (occurence.Value > maxPairLength)
							{
								maxPairLength = occurence.Value;
							}

							amountPairs++;
						}
					}

					calcValue = highestPairValue;

					if (amountPairs == 2)
					{
						// two pair
						offset = 2;
						if (occurences.Count == 2)
						{
							// full house
							offset = 6;
						}
					}
					else
					{
						switch (maxPairLength)
						{
							case 4: // four of a kind
								offset = 7;
								break;
							case 3: // three of a kind
								offset = 3;
								break;
							default: // one pair
								offset = 1;
								break;
						}
					}
				}
					
				if (isStraight && isFlush)
				{
					// straight flush
					offset = 8;
					if (calcValue == 14)
					{
						// royal flush
						offset++;
					}
				}
				else if (isStraight)
				{
					// straight
					offset = 4;
				}
				else if (isFlush)
				{
					// flush
					offset = 5;
				}
				
				calcValue += handOffsets[offset];

				return calcValue;
			}

			public int CompareTo(object obj)
			{
				int compareResult = 0;
				PokerHand otherHand = (PokerHand)obj;

				int thisValue = this.CalculateValue();
				int otherValue = otherHand.CalculateValue();
				if (thisValue == otherValue)
				{
					int index = 0;
					while (compareResult == 0 && index < 5)
					{
						compareResult = this.cards[index].Value - otherHand.cards[index].Value;
						index++;
					}
				}
				else
				{
					compareResult = thisValue - otherValue;
				}

				return compareResult;
			}
		}

		private class Card : IComparable
		{
			private static readonly IDictionary<char, int> cardValues = new Dictionary<char, int> 
				{ 
					{ '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'T', 10 }, { 'J', 11 }, { 'Q', 12 }, { 'K', 13 }, { 'A', 14 } 
				};

			public Card(string card)
			{
				this.Value = cardValues[card[0]];
				this.Color = card[1];
			}

			public int Value { get; private set; }

			public char Color { get; private set; }

			public int CompareTo(object obj)
			{
				Card otherCard = (Card)obj;
				return otherCard.Value - this.Value;
			}
		}

		[TestCase("5D 8C 9S JS AC", 14, TestName = "High card")]
		[TestCase("5H 5C 6S 7S KD", 20, TestName = "One pair")]
		[TestCase("5H 5C 6S 7S 7D", 37, TestName = "Two pair (V1)")]
		[TestCase("5H 6C 6S 7S 7D", 37, TestName = "Two pair (V2)")]
		[TestCase("5H 5C 6S 6H 7D", 36, TestName = "Two pair (V3)")]
		[TestCase("2D 9C AS AH AC", 59, TestName = "Three of a kind")]
		[TestCase("2D 3C 4S 5H 6C", 61, TestName = "Straight")]
		[TestCase("3D 6D 7D TD QD", 87, TestName = "Flush")]
		[TestCase("2H 2D 4C 4D 4S", 94, TestName = "Full House (V1)")]
		[TestCase("2H 2D 2C 4D 4S", 92, TestName = "Full House (V2)")]
		[TestCase("2H 4H 4C 4D 4S", 109, TestName = "Four of a kind")]
		[TestCase("2H 3H 4H 5H 6H", 126, TestName = "Straight Flush")]
		[TestCase("TS JS QS KS AS", 164, TestName = "Royal Flush")]
		public void TestForExamples(string hand, int value)
		{
			PokerHand pokerHand = new PokerHand(hand);

			Assert.AreEqual(value, pokerHand.Value);
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(376, this.Solution());
		}
	}
}