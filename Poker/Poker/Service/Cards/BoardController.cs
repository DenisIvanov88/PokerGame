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
        public static void DrawCards(int cardsToDraw)
        {
            for (int i = 0; i < cardsToDraw; i++)
            {
                CardData.Board.Add(CardController.DrawRandomCard());
            }
        }
    }
}
