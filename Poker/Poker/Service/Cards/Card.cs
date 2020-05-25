using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class Card
    {
        public Card(int number, char suit)
        {
            Number = number;
            Suit = suit;
        }

        public int Number { get;  private set; }
        public char Suit { get; private set; }

        public override string ToString()
        {
            char face = ' ';
            switch (Number)
            {
                case 11: face = 'J'; break;
                case 12: face = 'Q'; break;
                case 13: face = 'K'; break;
                case 14: face = 'A'; break;
            }

            if (face == ' ') return $"│{Number}{Suit}│";
            return $"│{face}{Suit}│";
        }
    }
}
