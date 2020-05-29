using Poker.Data;
using Poker.Service.Players;
using Poker.View;
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
                PrintMessageView.PrintNewLineMessage($"{Name} passed");
                ContextsData.MessageLogContext.AddMessageLog($"{Name} passed");
            }
        }
    }
}
