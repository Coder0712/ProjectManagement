using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    public interface IKanbanBoardService
    {
        /// <summary>
        /// Creates a kanban board.
        /// </summary>
        /// <param name="projectId">The id of the project.</param>
        /// <param name="name">The name of the board.</param>
        /// <returns>A new board.</returns>
        KanbanBoard CreateBoard(string name);

        /// <summary>
        /// Updates an existing board.
        /// </summary>
        /// <param name="name">The new name of the board.</param>
        /// <returns>A board with a new name.</returns>
        KanbanBoard UpdateBoard(Guid id, string name);

        /// <summary>
        /// Deletes a board.
        /// </summary>
        /// <param name="id">The id of the board.</param>
        void DeleteBoard(Guid id);

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
