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
        public static void AskUser()
        {
            if (BetController.UserCanCall())
            {
                Console.Write("Call/Raise/Fold? ");
            }
            else
            {
                Console.Write("Pass/Raise/Fold? ");
            }

            string[] command = Console.ReadLine().Trim().Split(' ').Where(x => x != "").Select(x => x.ToLower()).ToArray();
            if (command.Length > 1)
            {
                PlayerData.User.DoAction(command[0], uint.Parse(command[1]));
            }
            else
            {
                PlayerData.User.DoAction(command[0], 0);
            }
        }
    }
}
