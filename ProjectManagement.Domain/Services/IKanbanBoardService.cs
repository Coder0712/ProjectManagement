using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    public interface IKanbanBoardService
    {
        /// <summary>
        /// Creates a kanban board.
        /// </summary>
        /// <param name="name">The name of the board.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>A new board.</returns>
        KanbanBoard CreateBoard(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing board.
        /// </summary>
        /// <param name="id"> The id of the current board.</param>
        /// <param name="name">The new name of the board.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>A board with a new name.</returns>
        KanbanBoard UpdateBoard(Guid id, string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a board.
        /// </summary>
        /// <param name="id">The id of the board.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        void DeleteBoard(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all kanban boards.
        /// </summary>
        /// <returns></returns>
        List<KanbanBoard> GetBoards();

        /// <summary>
        /// Gets a board by its id.
        /// </summary>
        /// <param name="id">The id of the board.</param>
        /// <returns>A single board.</returns>
        KanbanBoard GetBoard(Guid id);
    }
}
