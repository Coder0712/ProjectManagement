using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents the response for getting a kanban board by its id.
    /// </summary>
    public sealed record GetKanbanBoardByIdResponse
    {
        /// <summary>
        /// Gets or sets the kanban board.
        /// </summary>
        public required Board KanbanBoard { get; set; }
    }
}
