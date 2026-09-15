using Microsoft.EntityFrameworkCore;
using MSALAWI.Domain.IdentityPerson;
using MSALAWI.Shared;

namespace MSALAWI.Infrastructure.Persistence;

public sealed class MsalawiDbContext(DbContextOptions<MsalawiDbContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var person = modelBuilder.Entity<Person>();
        person.ToTable("people");
        person.HasKey(x => x.Id);
        person.Property(x => x.Id)
            .HasConversion(id => id.Value, value => new EntityId(value))
            .ValueGeneratedNever();
        person.Property(x => x.FullName).HasMaxLength(250).IsRequired();
        person.Property(x => x.Email).HasMaxLength(320);
        person.HasIndex(x => x.Email);
    }
}
