using KitchenEquipmentOnlineShop.DataAccess.Entities;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenEquipmentOnlineShop.DataAccess.EF
{
    public class KitchenEquipmentContext : DbContext, IKitchenEquipmentContext
    {
        private static readonly string ConnectionString = @"Server=.;Database=kitchenequipment;Integrated Security=True;MultipleActiveResultSets=True;";

        public KitchenEquipmentContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExhaustHood> ExhaustHoods { get; set; }
        public DbSet<Sink> Sinks { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(l => l.ExhaustHoods)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(l => l.Sinks)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
