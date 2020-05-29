using Microsoft.EntityFrameworkCore;
using Poker.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.DBContexts
{
    public class RoundsPoolContext : DbContext
    {
        public DbSet<RoundsPool> RoundsPools { get; set; }

        public void AddRoudPool(int poolValue, string winnerName)
        {
            RoundsPool roundsPool = new RoundsPool() { Pool = poolValue, WinnerName = winnerName };
            RoundsPools.Add(roundsPool);
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Program.ConnectionString);
        }
    }
}
