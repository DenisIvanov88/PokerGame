using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.View
{
    public static class PrintMessageView
    {
        public static void PrintNewLineMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}
