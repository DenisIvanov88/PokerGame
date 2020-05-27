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
        public static void ShowWinner(Player player)
        {
            Console.WriteLine($"Winner is: {player.Name}!");
            CardView.PrintCards(player.BestHand.BestCards.ToArray(), player.Name);
        }
    }
}
