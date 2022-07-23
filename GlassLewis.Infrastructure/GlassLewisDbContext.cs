using Microsoft.EntityFrameworkCore;
using GlassLewis.Core.GlassLewis.Models;

namespace GlassLewis.Infrastructure
{
    public class GlassLewisDbContext : DbContext
    {
        public GlassLewisDbContext(DbContextOptions<GlassLewisDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>().Property(c => c.Id).ValueGeneratedOnAdd();
            //modelBuilder.HasSequence<int>("Id").StartsAt(1).IncrementsBy(1);

            //modelBuilder.Entity<UserInfo>().Property(c => c.UserId).ValueGeneratedOnAdd();
            //modelBuilder.HasSequence<int>("UserId").StartsAt(1).IncrementsBy(1);

            //Company
            modelBuilder.Entity<Company>()
                        .HasData(
                         new Company { Id = 1, Name = "Apple Inc.", Exchange = "NASDAQ", Ticker = "AAPL", ISIN = "US0378331005", Website = "http://www.apple.com" },
                         new Company { Id = 2, Name = "British Airways Plc.", Exchange = "Pink Sheets", Ticker = "BAIRY", ISIN = "US1104193065", Website = "" },
                         new Company { Id = 3, Name = "Heineken NV", Exchange = "Euronext Amsterdam", Ticker = "HEIA", ISIN = "NL0000009165", Website = "" },
                         new Company { Id = 4, Name = "Panasonic Corp", Exchange = "Tokyo Stock Exchange", Ticker = "6752", ISIN = "JP3866800000", Website = "http://www.panasonic.co.jp" },
                         new Company { Id = 5, Name = "Porsche Automobil", Exchange = "Deutsche Börse", Ticker = "PAH3", ISIN = "DE000PAH0038", Website = "https://www.porsche.com/" }
                         );

            //UserInfo
            modelBuilder.Entity<UserInfo>()
                        .HasData(
                             new UserInfo { UserId = 1, Email = "User1@abc.com", Password = "123456" },
                             new UserInfo { UserId = 2, Email = "User2@abc.com", Password = "123456" }
                         );

        }
    }
}
