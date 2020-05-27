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
        public static bool PlayerCanCall(Player player)
        {
            return GetHighestBet() > player.CurrentBid;
        }

        public static uint GetHighestBet()
        {
            return PlayerController.GetAllBets().Max();
        }
        public static uint GetSumOfBets()
        {
            return PlayerController.GetAllBets().Aggregate((x, y) => x + y);
        }
    }
}
