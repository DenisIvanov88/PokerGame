using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data.Tables
{
    [Table("roundspool", Schema = "poker")]
    public class RoundsPool
    {
        public int ID { get; set; }
        public int Pool { get; set; }
        public string WinnerName { get; set; }
    }
}
