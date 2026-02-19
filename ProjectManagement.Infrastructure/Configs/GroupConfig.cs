using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Configs
{
    internal class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title);

            builder.HasMany(g => g.Cards)
                .WithOne(c => c.Group)
                .HasForeignKey(c => c.GroupId);
        }
    }
}
