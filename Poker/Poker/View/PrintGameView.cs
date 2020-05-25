using Poker.Data;
using Poker.Service.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class PrintGameView
    {
        public static void PrintGame()
        {
            Console.Clear();

            PlayerInfoView.PrintAllNamesAndBets();
            BoardController.DrawCards();
            CardView.PrintBoard();
            CardView.PrintHand();
            Console.WriteLine(PlayerData.User.ToString());
            CommandView.AskUser();
        }
    }
}
