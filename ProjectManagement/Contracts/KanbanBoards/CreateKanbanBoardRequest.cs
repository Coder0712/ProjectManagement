namespace ProjectManagement.Contracts.KanbanBoards
{
    /// <summary>
    /// Represents a request to create a kanban board
    /// </summary>
    public sealed record CreateKanbanBoardRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }
    }
}
