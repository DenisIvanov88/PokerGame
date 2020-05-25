using Poker.Data;
using Poker.Service.Cards;
using Poker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class Engine
    {
        public static bool Playing { get; set; }
        public static void Start()
        {
            Playing = true;

            MainMenuView.Start();

            while (Playing)
            {
                PrintGameView.PrintGame();
            }
        }
    }
}