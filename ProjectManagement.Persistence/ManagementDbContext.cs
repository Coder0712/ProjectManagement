using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Services;
using System.Reflection;

namespace ProjectManagement.Persistence
{
    public sealed class ManagementDbContext 
        : DbContext, IDbContext
    {
        public ManagementDbContext(DbContextOptions options)
            :base(options) 
        { 
        }

        DbSet<Project> IDbContext.Project { get; set; }

        DbSet<KanbanBoard> IDbContext.KanbanBoards { get; set; }

        DbSet<ProjectKanbanBoardReference> IDbContext.ProjectKanbanBoardReferences { get; set; }

        DbSet<Cards> IDbContext.Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
