using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Common
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
        /// The cards db set.
        /// </summary>
        DbSet<Cards> Cards { get; set; }

        /// <summary>
        /// Saves the chnages in the database.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
