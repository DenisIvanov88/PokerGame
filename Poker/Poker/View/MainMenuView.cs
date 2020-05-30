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
            string balance = Console.ReadLine();
            try
            {
                uint.Parse(balance);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid data type!");
            }

            PlayerController.InitializeAllPlayers(name, uint.Parse(balance));
        }
        public static void ShowWinner(Player winner)
        {
            Console.WriteLine($"Winner is: {winner.Name}!");
            ContextsData.MessageLogContext.AddMessageLog($"Winner is: {winner.Name}!");
            CardView.PrintCards(winner.BestHand.BestCards.ToArray(), winner.Name);
        }
    }
}
