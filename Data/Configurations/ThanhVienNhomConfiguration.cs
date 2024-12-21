using AppChiaSeCongThucNauAnBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppChiaSeCongThucNauAnBackend.Data.Configurations;

public class ThanhVienNhomConfiguration : IEntityTypeConfiguration<ThanhVienNhom>
{
    public void Configure(EntityTypeBuilder<ThanhVienNhom> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Masv)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.HoVaTen)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
} 