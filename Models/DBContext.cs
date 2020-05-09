using KetchupMayoSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KetchupMayoSite.Controllers
{
    public class DBContext : DbContext
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ketchup>().HasData(new Ketchup
            {
                Id = 1,
                Name = "Ketchup Super pikantny",
                Brand = "Pudliszki",
                Spiciness = 6,
                ProductionDate = new DateTime(2019, 3, 30)
            }, new Ketchup
            {
                Id = 2,
                Name = "Ketchup Łagodny",
                Brand = "Pudliszki",
                Spiciness = 1,
                ProductionDate = new DateTime(2018, 1, 22)
            }
            );
            modelBuilder.Entity<Mayo>().HasData(new Mayo
            {
                Id = 1,
                Name = "Majonez zwykły",
                Brand = "Kielecki",
                Mildness = 9,
                ProductionDate = new DateTime(2019, 7, 30)
            }, new Mayo
            {
                Id = 2,
                Name = "Majonez Dekoracyjny",
                Brand = "Winiary",
                Mildness = 10,
                ProductionDate = new DateTime(2017, 1, 22)
            }
            );
        }
        public DbSet<Ketchup> Ketchups { get; set; }
        public DbSet<Mayo> Mayos { get; set; }
    }

}
