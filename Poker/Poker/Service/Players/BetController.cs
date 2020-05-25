using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Players
{
    public static class BetController
    {
        public static bool UserCanCall()
        {
            return GetHighestBet() > PlayerData.User.CurrentBid;
        }

        public static uint GetHighestBet()
        {
            return PlayerController.GetAllBets().Max();
        }
    }
}
