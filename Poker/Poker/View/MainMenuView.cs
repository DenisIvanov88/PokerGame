using Poker.Data;
using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class MainMenuView
    {
        public static void Start()
        {
            Console.Write("Username: ");
            string name = Console.ReadLine();
            Console.Write("Balance: ");
            uint balance = uint.Parse(Console.ReadLine());

            PlayerController.InitializeAllPlayers(name, balance);
        }
        public static void ShowWinner(Player winner)
        {
            Console.WriteLine($"Winner is: {winner.Name}!");
            ContextsData.MessageLogContext.AddMessageLog($"Winner is: {winner.Name}!");
            CardView.PrintCards(winner.BestHand.BestCards.ToArray(), winner.Name);
        }
    }
}
