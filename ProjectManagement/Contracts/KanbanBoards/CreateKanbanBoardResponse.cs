using ProjectManagement.Domain.Models;

namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents the response for creating a kanban board.
    /// </summary>
    public sealed record CreateKanbanBoardResponse
    {
        /// <summary>
        /// Gets or sets the kanban board.
        /// </summary>
        public required KanbanBoard KanbanBoard { get; set; }
    }
}
