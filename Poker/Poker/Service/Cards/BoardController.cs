using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Cards
{
    public static class BoardController
    {
        private static int drawRound = 0;
        public static void DrawCards()
        {
            int cardsToDraw = 1;
            switch (drawRound)
            {
                case 0: cardsToDraw = 0; break;
                case 1: cardsToDraw = 3; break;
            }

            for (int i = 0; i < cardsToDraw; i++)
            {
                CardData.Board.Add(CardController.DrawRandomCard());
            }

            drawRound++;

            if (drawRound == 4)
            {
                //DrawRound = 0, Decide winner
            }
        }
    }
}
