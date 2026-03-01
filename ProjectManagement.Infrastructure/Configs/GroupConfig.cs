using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Boards;
using ProjectManagement.Domain.Projects;

namespace ProjectManagement.Infrastructure.Configs
{
    internal class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title);

            builder.Property(g => g.CreatedAt)
                .IsRequired();

            builder.Property(g => g.LastModifiedAt)
                .IsRequired();

            builder.HasMany(g => g.Cards)
                .WithOne(c => c.Group)
                .HasForeignKey(c => c.GroupId);
        }
    }
}
