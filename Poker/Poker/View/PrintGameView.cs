using Poker.Data;
using Poker.Service.Cards;
using Poker.Service.Players;
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

            PlayerInfoView.PrintAllNamesAndBalances();
            CardView.PrintBoard();
            CardView.PrintHand();
            Console.WriteLine(PlayerData.User.ToString());
            Console.WriteLine($"Current pool: {BetController.GetSumOfBets()}");
            Console.WriteLine("Message log:");
        }
    }
}
