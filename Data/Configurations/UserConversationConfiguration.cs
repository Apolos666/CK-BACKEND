using AppChiaSeCongThucNauAnBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppChiaSeCongThucNauAnBackend.Data.Configurations;

public class UserConversationConfiguration : IEntityTypeConfiguration<UserConversation>
{
    public void Configure(EntityTypeBuilder<UserConversation> builder)
    {
        builder.HasKey(uc => new { uc.UserId, uc.ConversationId });

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserConversations)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uc => uc.Conversation)
            .WithMany(c => c.UserConversations)
            .HasForeignKey(uc => uc.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
