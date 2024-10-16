﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Infrastructure.Configs
{
    public class KanbanBoardConfig : IEntityTypeConfiguration<KanbanBoard>
    {
        public void Configure(EntityTypeBuilder<KanbanBoard> builder)
        {
            builder.ToTable("KanbanBoard");

            builder.HasKey(k => k.Id);

            builder.Property(k => k.Name);
        }
    }
}
