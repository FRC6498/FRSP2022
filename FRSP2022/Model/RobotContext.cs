using Microsoft.EntityFrameworkCore;

namespace FRSP2022
{
    public class RobotContext : DbContext
    {
        public DbSet<RobotModel> MatchResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
