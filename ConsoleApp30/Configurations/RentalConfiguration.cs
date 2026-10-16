using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ConsoleApp30.Configurations;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .HasOne(r => r.Car)
            .WithMany(c => c.Rental)
            .HasForeignKey(r => r.CarId);

        builder
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId);

        builder
            .HasMany(r => r.Penalties)
            .WithOne(p => p.Rental);

    }
}
