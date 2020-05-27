using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Cards
{
    public class BestHand
    {
        public List<Card> BestCards = new List<Card>();
        public int Value;

        public static void SetBestCards(Player player)
        {
            CheckForFlush(player);
            if (player.BestHand.Value == 0)
            {
                CheckForStraight(player);
            }
            if (player.BestHand.Value == 0)
            {
                List<Card> orderedCards = player.HandAndBoard.OrderByDescending(x => x.Number).ToList();
                List<Card> sameNumberedCards = orderedCards.Where(x => orderedCards.Count(y => y.Number == x.Number) > 1).ToList();
                int sameCardsCount = sameNumberedCards.Count;

                switch (sameCardsCount)
                {
                    case 0: player.BestHand.BestCards = GetStrongestNumberedCards(orderedCards, 5);
                        break;
                    case 2: //Pair
                    case 3: //Set
                    case 5: //Set + pair
                        player.BestHand.BestCards = sameNumberedCards;
                        player.BestHand.Value = sameCardsCount + sameCardsCount - (int)(Math.Floor(sameCardsCount / 2.0) + 1);
                        player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 5 - sameCardsCount));
                        break;
                    case 4: //Quad / Pair + pair
                        player.BestHand.BestCards = sameNumberedCards;
                        player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 1));
                        player.BestHand.Value = (MaxSameNumberCount(sameNumberedCards) == 4) ? 8 : 3;
                        break;
                    case 6:
                        //player.BestHand.Value = (MaxSameNumberCount(sameNumberedCards) == 4) ? 8 : (MaxSameNumberCount(sameNumberedCards) == 3) ? 7 : 3;
                        if (MaxSameNumberCount(sameNumberedCards) == 4) //Quad + pair
                        {
                            player.BestHand.Value = 8;
                            sameNumberedCards = sameNumberedCards.Where(x => sameNumberedCards.Count(y => y.Number == x.Number) > 3).ToList();
                            player.BestHand.BestCards = sameNumberedCards;
                            player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 1));
                        }
                        else if (MaxSameNumberCount(sameNumberedCards) == 2) //Pair + pair + pair
                        {
                            player.BestHand.Value = 3;
                            sameNumberedCards.RemoveRange(4, 2);
                            player.BestHand.BestCards = sameNumberedCards;
                            player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 1));
                        }
                        else //Set + Set
                        {
                            player.BestHand.Value = 7;
                            sameNumberedCards.RemoveAt(5);
                            player.BestHand.BestCards = sameNumberedCards;
                        }
                        break;
                    case 7:
                        if (MaxSameNumberCount(sameNumberedCards) == 4) //Quad + set
                        {
                            player.BestHand.Value = 8;
                            sameNumberedCards = sameNumberedCards.Where(x => sameNumberedCards.Count(y => y.Number == x.Number) > 3).ToList();
                            player.BestHand.BestCards = sameNumberedCards;
                            player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 1));
                        }
                        else //Set + pair + pair
                        {
                            player.BestHand.Value = 7;
                            sameNumberedCards = sameNumberedCards.Where(x => sameNumberedCards.Count(y => y.Number == x.Number) > 2).ToList();
                            player.BestHand.BestCards = sameNumberedCards;
                            player.BestHand.BestCards.AddRange(GetStrongestNumberedCards(orderedCards.Except(sameNumberedCards).ToList(), 2));
                        }
                        break;
                }
            }
        }
        private static void CheckForFlush(Player player)
        {
            Card[] orderedCards = player.HandAndBoard.OrderByDescending(x => x.Number).ToArray();
            char mostCommonSuit = orderedCards.Select(x => x.Suit).OrderByDescending(x => orderedCards.Count(card => card.Suit == x)).First();
            List<Card> flushCards = orderedCards.Where(x => x.Suit == mostCommonSuit).ToList();

            if (flushCards.Count >= 5)
            {
                player.BestHand.Value = 6;

                var tmpCards = player.HandAndBoard;
                player.HandAndBoard = flushCards;
                CheckForStraight(player);
                player.HandAndBoard = tmpCards;

                if (player.BestHand.Value == 5)
                {
                    player.BestHand.Value = 9;
                }
                else
                {
                    player.BestHand.BestCards = GetStrongestNumberedCards(flushCards, 5);
                }
            }
        }
        private static void CheckForStraight(Player player)
        {
            Card[] orderedCards = player.HandAndBoard.OrderByDescending(x => x.Number).ToArray();
            List<Card> straightCards = new List<Card>();
            int sequenceCount = 1;

            for (int i = 0; i < orderedCards.Length - 1; i++)
            {
                if (orderedCards[i].Number == orderedCards[i + 1].Number + 1)
                {
                    sequenceCount++;
                    straightCards.Add(orderedCards[i]);
                    if (sequenceCount == 5 && player.BestHand.Value != 9)
                    {
                        straightCards.Add(orderedCards[i + 1]);
                        player.BestHand.Value = 5;
                        player.BestHand.BestCards.AddRange(straightCards);
                        break;
                    }
                }
                else if (orderedCards[i].Number != orderedCards[i + 1].Number)
                {
                    sequenceCount = 1;
                    straightCards = new List<Card>();
                }
            }
        }
        private static List<Card> GetStrongestNumberedCards(List<Card> cards, int cardsToReturn)
        {
            cards = cards.OrderByDescending(x => x.Number).ToList();

            return cards.Take(cardsToReturn).ToList();
        }
        private static int MaxSameNumberCount(List<Card> cards)
        {
            return cards.Select(card => cards.Count(c => c.Number == card.Number)).Distinct().Max();
        }
    }
}
