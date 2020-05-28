using Poker.Data;
using Poker.Service;
using Poker.Service.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class CommandView
    {
        public static string[] AskUser()
        {
            if (BetController.GetHighestBet() > PlayerData.User.CurrentBid)
            {
                Console.Write("Call/Raise/Fold? ");
            }
            else
            {
                Console.Write("Pass/Raise/Fold? ");
            }

            string[] command = Console.ReadLine().Trim().Split(' ').Select(x => x.ToLower()).ToArray();
            return command;
        }
    }
}
