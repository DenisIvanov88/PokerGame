using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Cards
{
    public class HandAndBoard
    {
        public HandAndBoard()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
    }
}
