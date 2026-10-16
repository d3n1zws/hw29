

using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp30.Configurations;

public class MaintenanceRecordConfiguration : IEntityTypeConfiguration<MaintenanceRecord>
{
    public void Configure(EntityTypeBuilder<MaintenanceRecord> builder)
    {
        builder
            .HasOne(m => m.Car)
            .WithMany(c => c.MaintenanceRecords)
            .HasForeignKey(m => m.CarId);

        builder
            .HasKey(m => m.Id);
    }
}
