namespace ProjectManagement.Contracts.ProjectKanbanBoards
{
    /// <summary>
    /// Represents the project kanban board reference request.
    /// </summary>
    public sealed record CreateProjectKanbanBoardReference
    {
        /// <summary>
        /// Gets or sets the kanban board id.
        /// </summary>
        public required Guid KanbanBoardId { get; set; }
    }
}
