namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents a request to update a kanban board.
    /// </summary>
    public sealed record UpdateKanbanBoardRequst
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }
    }
}
