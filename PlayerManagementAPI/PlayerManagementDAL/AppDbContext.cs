using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagementDAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Ground> Grounds { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RugbyUnion> RugbyUnions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ITBIID1\\SQLEXPRESS;Initial Catalog=RugbyClub;Integrated Security=True");
            }
        }

    }
}
