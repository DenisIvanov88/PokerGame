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
        public static void InitializeMainPlayer(string name, uint balance)
        {
            PlayerData.User = new User(name, balance);
            
            PlayerData.User.AddCards(CardController.DrawRandomCard(), CardController.DrawRandomCard());
        }

        public static Player[] GetAllPlayers()
        {
            return new Player[] { PlayerData.User };
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
