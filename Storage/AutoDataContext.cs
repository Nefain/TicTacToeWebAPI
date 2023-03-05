using Microsoft.EntityFrameworkCore;
using Tic_Tac_ToeWebAPI.Models;

namespace Tic_Tac_ToeWebAPI.Storage
{
    public class AutoDataContext : DbContext
    {
        public AutoDataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
        public DbSet<TicTacToe> TicTacToes { get; set; }
    }
}
