using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class TaxDefinitionDbContext : DbContext
    {

        public TaxDefinitionDbContext(DbContextOptions<TaxDefinitionDbContext> options) : base(options) { }

        public DbSet<TaxDefinition> TaxDefinitions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxDefinition>()
                .Property(e => e.CustomerType)
                .HasConversion<int>(); // CustomerType sayısal değerini veritabanında saklar

            modelBuilder.Entity<TaxDefinition>()
                .Property(e => e.TaxCalculationType)
                .HasConversion<int>(); // TaxCalculationType sayısal değerini veritabanında saklar
        }
    }
}
