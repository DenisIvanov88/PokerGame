using Poker.Service.Players;
using Poker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class User : Player
    {
        public User(string name, uint initialBalance) : base(name, initialBalance)
        {
        }

        public override void DoAction()
        {
            string[] command = CommandView.AskUser().ToArray();
            switch (command[0])
            {
                case "raise":
                    if (uint.Parse(command[1]) > this.Balance)
                    {
                        Console.WriteLine("Invalid amount! Amount must be lower than user's balance!");
                        this.DoAction();
                    }
                    else
                    {
                        base.Raise(uint.Parse(command[1]));
                    }
                    break;
                case "call":
                    if (BetController.PlayerCanCall(this))
                    {
                        base.Call();
                    }
                    break;
                case "fold": base.Fold(); break;
                case "stop":
                case "end": Engine.Playing = false; break;
                default: Console.WriteLine($"{Name} passed"); break;
            }
        }
    }
}
