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

        public void DoAction(string command, uint value)
        {
            switch (command)
            {
                case "call": this.Call(); break;
                case "raise": this.Raise(value); break;
                case "fold": this.Fold(); break;
                case "end":
                case "stop": Engine.Playing = false; break;
            }
        }
    }
}
