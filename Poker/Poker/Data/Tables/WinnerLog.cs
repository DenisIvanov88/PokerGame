using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data.Tables
{
    [Table("winnerlog", Schema = "poker")]
    public class WinnerLog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Card1Number { get; set; }
        public int Card2Number { get; set; }
        public int Card3Number { get; set; }
        public int Card4Number { get; set; }
        public int Card5Number { get; set; }
        public string Card1Suit { get; set; }
        public string Card2Suit { get; set; }
        public string Card3Suit { get; set; }
        public string Card4Suit { get; set; }
        public string Card5Suit { get; set; }
    }
}
