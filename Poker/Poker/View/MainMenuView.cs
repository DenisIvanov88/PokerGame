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

            PlayerController.InitializeMainPlayer(name, balance);

            PrintGameView.PrintGame();
        }
    }
}
