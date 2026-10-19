using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Configurations;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Rental)
            .WithMany(r => r.Penalties)
            .HasForeignKey(p => p.RentalId);
    }
}
