using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp30.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasMany(c => c.Rental)
            .WithOne(r => r.Car);

        builder
            .HasMany(c => c.MaintenanceRecords)
            .WithOne(r => r.Car);

        builder
            .Property(c => c.Brand)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(c => c.PlateNumber)
            .IsRequired()
            .HasMaxLength(30);
    }
}
