using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Boards;
using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Projects;
using System.Reflection;

namespace ProjectManagement.Infrastructure
{
    public sealed class ManagementDbContext 
        : DbContext, IDbContext
    {
        public ManagementDbContext(DbContextOptions options)
            :base(options) 
        { 
        }

        DbSet<Project> IDbContext.Project { get; set; }

        DbSet<Board> IDbContext.Board { get; set; }

        DbSet<Group> IDbContext.Group { get; set; }

        DbSet<Card> IDbContext.Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
