using Poker.Data;
using Poker.Service;
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
            int currentPhase = 1;

            MainMenuView.Start();

            while (Playing)
            {
                GameController.Phase(currentPhase);
                if (currentPhase == 6)
                {
                    Console.Write("Would you like to continue playing? YES/NO ");
                    string command = Console.ReadLine().Trim().ToLower();
                    if (command == "yes")
                    {
                        currentPhase = 0;
                        ResetGame();
                    }
                    else
                    {
                        Playing = false;
                    }
                }
                currentPhase++;
            }
        }
        private static void ResetGame()
        {
            foreach (var player in PlayerController.GetAllPlayers())
            {
                player.ResetPlayer();
            }
            CardData.DrawnCards = new List<Card>();
            CardData.Board = new List<Card>();
        }
    }
}