
using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .HasMany(c => c.Rentals)
            .WithOne(r => r.Customer);

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .HasAlternateKey(c => c.Email);

        builder
            .Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(30);
    }
}