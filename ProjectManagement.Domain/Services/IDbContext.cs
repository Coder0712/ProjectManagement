using ProjectManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Domain
{
    /// <summary>
    /// A default implementation for the db context.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// The project db set.
        /// </summary>
        DbSet<Project> Project { get; set; }

        /// <summary>
        /// The kanban board db set.
        /// </summary>
        DbSet<KanbanBoard> KanbanBoards { get; set; }

        /// <summary>
        /// The project kanban board reference db set.
        /// </summary>
        DbSet<ProjectKanbanBoardReference> ProjectKanbanBoardReferences { get; set; }

        /// <summary>
        /// Saves the chnages in the database.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
