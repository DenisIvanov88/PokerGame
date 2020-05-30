using Microsoft.EntityFrameworkCore;
using Poker.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data.DBContexts
{
    public class MessageLogContext : DbContext
    {
        public DbSet<MessageLog> MessageLogs { get; set; }
        
        public void AddMessageLog(string message)
        {
            MessageLog messageLog = new MessageLog() { Message = message, Time = DateTime.Now };
            MessageLogs.Add(messageLog);
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Program.ConnectionString);
        }
    }
}
