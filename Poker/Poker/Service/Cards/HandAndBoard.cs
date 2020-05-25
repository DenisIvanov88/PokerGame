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
            Values = new List<int>();
        }

        public List<Card> Cards { get; set; }
        public List<int> Values { get; set; }
    }
}
