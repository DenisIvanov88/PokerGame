using Poker.Data;
using Poker.Service.Cards;
using Poker.Service.Players;
using Poker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public static class GameController
    {
        public static void Phase(int currentPhase)
        {
            if (currentPhase == 1)
            {
                List<Player> players = PlayerController.GetAllPlayers().Where(x => x.NotFolded).ToList();

                foreach (var player in players)
                {
                    player.AddCards(CardController.DrawRandomCard(), CardController.DrawRandomCard());
                }

                BoardController.DrawCards(0);
                PrintGameView.PrintGame();

                PlayersDoActionUntillAllBetsAreEqual(players);
            }
            else if (currentPhase == 2)
            {
                List<Player> players = PlayerController.GetAllPlayers().Where(x => x.NotFolded).ToList();

                BoardController.DrawCards(3);
                PrintGameView.PrintGame();

                PlayersDoActionUntillAllBetsAreEqual(players);
            }
            else if (currentPhase == 3)
            {
                List<Player> players = PlayerController.GetAllPlayers().Where(x => x.NotFolded).ToList();

                BoardController.DrawCards(1);
                PrintGameView.PrintGame();

                PlayersDoActionUntillAllBetsAreEqual(players);
            }
            else if (currentPhase == 4)
            {
                List<Player> players = PlayerController.GetAllPlayers().Where(x => x.NotFolded).ToList();

                BoardController.DrawCards(1);
                PrintGameView.PrintGame();

                PlayersDoActionUntillAllBetsAreEqual(players);
            }
            else if (currentPhase == 5)
            {
                List<Player> players = PlayerController.GetAllPlayers().Where(x => x.NotFolded).ToList();

                Player winner = DecideWinner(players);
                winner.Balance += PlayerController.GetAllBets().Aggregate((x, y) => x + y);
                MainMenuView.ShowWinner(winner);
            }
        }
        private static void PlayersDoActionUntillAllBetsAreEqual(List<Player> players)
        {
            bool allBetsAreNotEqual = true;

            while (allBetsAreNotEqual)
            {
                AllPlayersDoAction(players);
                if (PlayerController.GetAllBets().All(x => x == PlayerController.GetAllBets()[3]))
                {
                    allBetsAreNotEqual = false;
                }
            }
        }
        private static void AllPlayersDoAction(List<Player> players)
        {
            foreach (var player in players)
            {
                player.DoAction();
            }
        }
        private static Player DecideWinner(List<Player> players)
        {
            foreach (var player in players)
            {
                player.HandAndBoard = player.Hand;
                player.HandAndBoard.AddRange(CardData.Board);
            }
            foreach (var player in players)
            {
                BestHand.SetBestCards(player);
            }

            Player bestPlayer = players[0];
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].BestHand.Value > bestPlayer.BestHand.Value)
                {
                    bestPlayer = players[i];
                }
                else if (players[i].BestHand.Value == players[i].BestHand.Value)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (players[i].BestHand.BestCards[j].Number > bestPlayer.BestHand.BestCards[j].Number)
                        {
                            bestPlayer = players[i];
                            break;
                        }
                        else if (players[i].BestHand.BestCards[j].Number < bestPlayer.BestHand.BestCards[j].Number)
                        {
                            break;
                        }
                    }
                }
            }
            return bestPlayer;
        }
    }
}
