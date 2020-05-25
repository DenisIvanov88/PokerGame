using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public static class CardController
    {
        private static Random rndm = new Random();
        public static Card[] GetPlayerHand()
        {
            return PlayerData.User.Hand.ToArray();
        }

        public static Card DrawRandomCard()
        {
            if (CardData.DrawnCards.Count == 52)
            {
                throw new IndexOutOfRangeException("All cards have been drawn from the deck!");
            }
            int rndmNumber = 0;
            char rndmSuit = ' ';

            do
            {
                rndmNumber = rndm.Next(2, 15);
                switch (rndm.Next(1, 5))
                {
                    case 1: rndmSuit = 'C'; break;
                    case 2: rndmSuit = 'D'; break;
                    case 3: rndmSuit = 'H'; break;
                    case 4: rndmSuit = 'S'; break;
                }
            } while (CardData.DrawnCards.Any(x => x.Number == rndmNumber && x.Suit == rndmSuit));

            Card rndmCard = new Card(rndmNumber, rndmSuit);
            CardData.DrawnCards.Add(rndmCard);

            return rndmCard;
        }
    }
}
