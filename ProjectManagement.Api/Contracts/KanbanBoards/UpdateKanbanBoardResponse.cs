using ProjectManagement.Domain.Models;

namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents the response to update a kanban board.
    /// </summary>
    public sealed record UpdateKanbanBoardResponse
    {
        /// <summary>
        /// Gets or sets the kanban board.
        /// </summary>
        public required KanbanBoard KanbanBoard { get; set; }
    }
}
