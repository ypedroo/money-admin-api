using Microsoft.EntityFrameworkCore;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Infra.Data
{
    public class MoneyAdminContext : DbContext
    {
        public MoneyAdminContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=localhost,1433; Database=Master; User Id=SA; Password=MoneyAdmin@123");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
