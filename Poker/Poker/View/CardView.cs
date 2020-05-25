using Poker.Data;
using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class CardView
    {
        public static void PrintBoard()
        {
            PrintCards(CardData.Board.ToArray(), "Board");
        }
        public static void PrintHand()
        {
            PrintCards(CardController.GetPlayerHand(), "Hand");
        }

        private static void PrintCards(Card[] cards, string sender)
        {
            StringBuilder sb = new StringBuilder(new string(' ', sender.Length + 2));


            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].ToString().Length == 5)
                {
                    sb.Append("┌───┐");
                }
                else
                {
                    sb.Append("┌──┐");
                }
            }
            Console.WriteLine(sb);
            sb.Clear();

            sb.Append(sender + ": ");
            foreach (var card in cards)
            {
                sb.Append(card.ToString());
            }
            Console.WriteLine(sb);
            sb.Clear();

            sb.Append(new string(' ', sender.Length + 2));
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].ToString().Length == 5)
                {
                    sb.Append("└───┘");
                }
                else
                {
                    sb.Append("└──┘");
                }
            }
            Console.WriteLine(sb);
        }
    }
}
