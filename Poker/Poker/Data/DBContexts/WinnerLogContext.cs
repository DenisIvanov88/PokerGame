using Microsoft.EntityFrameworkCore;
using Poker.Data.Tables;
using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data.DBContexts
{
    public class WinnerLogContext : DbContext
    {
        public DbSet<WinnerLog> WinnerLogs { get; set; }
        public void AddWinner(Player player)
        {
            WinnerLog winnerLogTable = new WinnerLog()
            {
                Name = player.Name,
                Value = player.BestHand.Value,
                Card1Number = player.BestHand.BestCards[0].Number, Card1Suit = player.BestHand.BestCards[0].Suit.ToString(),
                Card2Number = player.BestHand.BestCards[1].Number, Card2Suit = player.BestHand.BestCards[1].Suit.ToString(),
                Card3Number = player.BestHand.BestCards[2].Number, Card3Suit = player.BestHand.BestCards[2].Suit.ToString(),
                Card4Number = player.BestHand.BestCards[3].Number, Card4Suit = player.BestHand.BestCards[3].Suit.ToString(),
                Card5Number = player.BestHand.BestCards[4].Number, Card5Suit = player.BestHand.BestCards[4].Suit.ToString()
            };
            WinnerLogs.Add(winnerLogTable);
            this.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Program.ConnectionString);
        }
    }
}
