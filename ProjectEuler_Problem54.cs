using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Oyster.Math;

namespace ProjectEuler_01
{
	class Program
	{
		public static Stopwatch sw;
		enum PokerDeals : int { HighCard, OnePair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush };

		static PokerDeals GetPokerDeal(string s, out int highestCard, out int highestCardInHand)
		{
			int countOfSameCards = 1;
			int currentHighestCard = 0;
			int highestCardInHandSaved = 0;
			bool[] usedCards = new bool[10];
			List<int> advanceCards = new List<int>();
			highestCardInHand = 0;
			highestCard = 0;
			string advanceString = "";

			bool onePair = false;
			bool twoPairs = false;
			bool threeOfAKind = false;
			bool straight = true;
			bool flush = true;
			bool fourOfAKind = false;
			bool possibleRoyalFlush = false;

			s = s.Replace(" ", "");

			for (int i = 0; i < s.Length - 2; i += 2)  // Pairs, tripples, quarters, full house
			{
				for (int j = i + 2; j < s.Length; j += 2)
				{
					if (i == j) continue;

					if (!usedCards[j] && s[i] == s[j])
					{
						usedCards[j] = true;
						usedCards[i] = true;

						countOfSameCards++;
						advanceString = s.Substring(j, 1);
						advanceString = advanceString.Replace("T", "10");
						advanceString = advanceString.Replace("J", "11");
						advanceString = advanceString.Replace("Q", "12");
						advanceString = advanceString.Replace("K", "13");
						advanceString = advanceString.Replace("A", "14");

						if (int.Parse(advanceString) > currentHighestCard)
							currentHighestCard = int.Parse(advanceString);
					}
				}

				if (countOfSameCards == 2)
				{					
					if (onePair)
						twoPairs = true;
					onePair = true;

					if (!threeOfAKind)
						highestCard = currentHighestCard;

					for (int j = 0; j < s.Length; j += 2)
					{
						if (!usedCards[j])
						{
							advanceString = s.Substring(j, 1);
							advanceString = advanceString.Replace("T", "10");
							advanceString = advanceString.Replace("J", "11");
							advanceString = advanceString.Replace("Q", "12");
							advanceString = advanceString.Replace("K", "13");
							advanceString = advanceString.Replace("A", "14");

							if (highestCardInHandSaved < int.Parse(advanceString))
								highestCardInHandSaved = int.Parse(advanceString);
						}
					}
				}

				if (countOfSameCards == 3)
				{
					threeOfAKind = true;
					highestCard = currentHighestCard;
				}

				if (countOfSameCards == 4)
				{
					highestCard = currentHighestCard;
					fourOfAKind = true;
				}
				

				countOfSameCards = 1;
				currentHighestCard = 0;
			}
			
			for (int i = 0; i < s.Length; i += 2)
			{				
				advanceString = s.Substring(i, 1);
				advanceString = advanceString.Replace("T", "10");
				advanceString = advanceString.Replace("J", "11");
				advanceString = advanceString.Replace("Q", "12");
				advanceString = advanceString.Replace("K", "13");
				advanceString = advanceString.Replace("A", "14");

				if (highestCardInHand < int.Parse(advanceString))				
					highestCardInHand = int.Parse(advanceString);
				
				if (advanceString == "14")
					possibleRoyalFlush = true;
				
				advanceCards.Add(int.Parse(advanceString));
			}
			
			advanceCards.Sort();
			int currentNumber = advanceCards[0];

			for (int i = 0; i < 5; i++)
			{
				if (advanceCards[i] != currentNumber)
					straight = false;

				currentNumber++;
			}
			if (straight)
				highestCard = advanceCards[4];

			for (int i = 1; i < s.Length; i += 2)
			{
				advanceString = s.Substring(i - 1, 1);
				advanceString = advanceString.Replace("T", "10");
				advanceString = advanceString.Replace("J", "11");
				advanceString = advanceString.Replace("Q", "12");
				advanceString = advanceString.Replace("K", "13");
				advanceString = advanceString.Replace("A", "14");

				if (currentHighestCard < int.Parse(advanceString))
					currentHighestCard = int.Parse(advanceString);
				
				if (s[1] != s[i])
					flush = false;
			}

			if (flush)
				highestCard = currentHighestCard;

			if (flush && straight && possibleRoyalFlush)			
				return PokerDeals.RoyalFlush;
			if (flush && straight)
				return PokerDeals.StraightFlush;
			if (fourOfAKind)			
				return PokerDeals.FourOfAKind;			
			if (onePair && threeOfAKind)			
				return PokerDeals.FullHouse;
			if (flush)			
				return PokerDeals.Flush;
			if (straight)			
				return PokerDeals.Straight;
			if (threeOfAKind)
				return PokerDeals.ThreeOfAKind;
			if (twoPairs)
				return PokerDeals.TwoPairs;
			if (onePair)
			{
				highestCardInHand = highestCardInHandSaved;
				return PokerDeals.OnePair;
			}

			return PokerDeals.HighCard;
		}

		static void Main(string[] args)
		{
			StartingProcedures();

			PokerDeals playerOneHand = new PokerDeals();
			PokerDeals playerTwoHand = new PokerDeals();
			int playerOneHighestCard = 0;
			int playerTwoHighestCard = 0;
			int playerOneHighestCardInHand = 0;
			int playerTwoHighestCardInHand = 0;
			int playerOneWins = 0;
			int playerTwoWins = 0;

			using (StreamReader streamReader = new StreamReader("poker.txt"))
			{
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{
					playerOneHand = GetPokerDeal(line.Substring(0, 14), out playerOneHighestCard, out playerOneHighestCardInHand);
					playerTwoHand = GetPokerDeal(line.Substring(14, 15), out playerTwoHighestCard, out playerTwoHighestCardInHand);					

					if (playerOneHand == playerTwoHand)
					{
						if (playerOneHighestCard > playerTwoHighestCard)
							playerOneWins++;
						else if (playerOneHighestCard < playerTwoHighestCard)
							playerTwoWins++;
						else
						{
							if (playerOneHighestCardInHand < playerTwoHighestCardInHand)
								playerTwoWins++;
							else
								playerOneWins++;
						}

					}
					else if (playerOneHand > playerTwoHand)					
						playerOneWins++;
					else
						playerTwoWins++;
					
				}				
				streamReader.Close();
			}
			
			System.Console.WriteLine("Player one won " + playerOneWins.ToString() + " tables");								
			
			ClosingProcedures();
		}

		#region HelpMethods

		static void StartingProcedures()
		{
			sw = new Stopwatch();
			sw.Start();
		}

		static void ClosingProcedures()
		{
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();
		}

		#endregion

	}
}
