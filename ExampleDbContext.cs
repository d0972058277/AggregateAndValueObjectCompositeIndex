using AggregateAndValueObjectCompositeIndex.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace AggregateAndValueObjectCompositeIndex
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var accountBuilder = modelBuilder.Entity<Account>();

            accountBuilder.ToTable("Account");
            accountBuilder.Ignore(a => a.DomainEvents);
            accountBuilder.HasKey(a => a.Id);
            accountBuilder.Property(a => a.Username).HasMaxLength(16);
            accountBuilder.Property(a => a.Password).HasMaxLength(16);
            accountBuilder.OwnsOne(a => a.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Value).HasColumnName("Email").HasMaxLength(16);
                emailBuilder.WithOwner();

                // emailBuilder.HasIndex("Username", "Email");
            });

            // accountBuilder.HasIndex("Username", "Email");
            // accountBuilder.HasIndex(a => new { a.Username, a.Email.Value });

            // NOTE: https://github.com/dotnet/efcore/issues/11336
        }
    }
}