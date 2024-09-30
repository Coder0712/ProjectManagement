using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Persistence.Configs
{
    public class ProjectKanbanBoardReferenceConfig : IEntityTypeConfiguration<ProjectKanbanBoardReference>
    {
        public void Configure(EntityTypeBuilder<ProjectKanbanBoardReference> builder)
        {
            builder.ToTable("ProjectKanbanBoardReference");

            builder.HasKey(k => k.Id);

            builder.HasOne<KanbanBoard>()
                   .WithMany(k => k.References)
                   .HasForeignKey(k => k.KanbanBoardId);

            builder.HasOne<Project>()
                   .WithMany(p => p.References)
                   .HasForeignKey(k => k.ProjectId);
        }
    }
}
