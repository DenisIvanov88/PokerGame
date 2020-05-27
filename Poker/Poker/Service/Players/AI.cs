using Poker.Service.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class AI : Player
    {
        public AI(string name, uint initialBalance) : base(name, initialBalance)
        {
        }
        public override void DoAction()
        {
            if (BetController.PlayerCanCall(this))
            {
                base.Call();
            }
            else
            {
                Console.WriteLine($"{Name} passed");
            }
        }
    }
}
