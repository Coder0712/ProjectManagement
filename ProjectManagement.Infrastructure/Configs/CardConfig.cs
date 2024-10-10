using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Infrastructure.Configs
{
    internal class CardConfig : IEntityTypeConfiguration<Cards>
    {
        public void Configure(EntityTypeBuilder<Cards> builder)
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

            builder.HasOne<KanbanBoard>()
                .WithMany(k => k.Cards)
                .HasForeignKey(c => c.BoardId);
        }
    }
}
