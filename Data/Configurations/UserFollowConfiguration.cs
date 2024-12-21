using AppChiaSeCongThucNauAnBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppChiaSeCongThucNauAnBackend.Data.Configurations;

public class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {
        builder.HasKey(uf => new { uf.FollowerId, uf.FollowingId });

        builder.HasOne(uf => uf.Follower)
            .WithMany(u => u.Following)
            .HasForeignKey(uf => uf.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(uf => uf.Following)
            .WithMany(u => u.Followers)
            .HasForeignKey(uf => uf.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(uf => uf.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}