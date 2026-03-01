using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Infrastructure.Configs
{
    internal class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired();

            builder.Property(c => c.Description)
                .IsRequired();

            builder.Property(c => c.Effort)
                .IsRequired();

            builder.Property(c => c.Status)
                .IsRequired();

            builder.Property(g => g.CreatedAt)
                .IsRequired();

            builder.Property(g => g.LastModifiedAt)
                .IsRequired();
        }
    }
}
