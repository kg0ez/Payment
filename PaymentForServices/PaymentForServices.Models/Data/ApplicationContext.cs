using System;
using Microsoft.EntityFrameworkCore;
using PaymentForServices.Models.Models;

namespace PaymentForServices.Models.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<HistoryPayment> HistoryPayments { get; set; } = null!;
        public DbSet<CreaditCard> CreaditCards { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.CreaditCard)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.HistoryPayments)
                .WithOne(hp => hp.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Categories)
                .WithOne(c => c.Service)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Payment;User Id=sa;Password=Valuetech@123;");
        }
    }
}

