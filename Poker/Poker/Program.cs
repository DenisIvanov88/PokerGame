using Poker.Data;
using Poker.Service;
using Poker.Service.Cards;
using Poker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        public const string ConnectionString = 
            "server=localhost; port=3306; user id=root; password=password; database=poker; SslMode=none";
        static void Main(string[] args)
        {
            Engine.Start();
        }
    }
}
