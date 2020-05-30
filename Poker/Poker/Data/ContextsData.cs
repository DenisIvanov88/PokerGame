using Poker.Data.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data
{
    public static class ContextsData
    {
        public static WinnerLogContext WinnerLogContext = new WinnerLogContext();
        public static MessageLogContext MessageLogContext = new MessageLogContext();
        public static RoundsPoolContext RoundsPoolContext = new RoundsPoolContext();
    }
}
