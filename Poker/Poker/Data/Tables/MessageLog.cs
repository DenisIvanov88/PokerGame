using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data.Tables
{
    [Table("messagelog", Schema = "poker")]
    public class MessageLog
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
