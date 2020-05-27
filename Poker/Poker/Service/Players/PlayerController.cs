using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public static class PlayerController
    {
        public static void InitializeAllPlayers(string name, uint balance)
        {
            PlayerData.Player1 = new AI("AI1", balance);
            PlayerData.Player2 = new AI("AI2", balance);
            PlayerData.User = new User(name, balance);
            PlayerData.Player3 = new AI("AI3", balance);
        }

        public static Player[] GetAllPlayers()
        {
            return new Player[] { PlayerData.Player1, PlayerData.Player2, PlayerData.User, PlayerData.Player3 };
        }
        public static string[] GetAllNames()
        {
            return GetAllPlayers().Select(x => x.Name).ToArray();
        }
        public static uint[] GetAllBets()
        {
            return GetAllPlayers().Select(x => x.CurrentBid).ToArray();
        }
        public static uint[] GetAllBalances()
        {
            return GetAllPlayers().Select(x => x.Balance).ToArray();
        }
    }
}
