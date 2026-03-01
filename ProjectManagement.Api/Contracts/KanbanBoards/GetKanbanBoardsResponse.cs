using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents the response to get all kanban baords.
    /// </summary>
    public sealed record GetKanbanBoardsResponse
    {
        /// <summary>
        /// Gets or sets the kanban boards.
        /// </summary>
        public required List<Board> KanbanBoards { get; set; }
    }
}
