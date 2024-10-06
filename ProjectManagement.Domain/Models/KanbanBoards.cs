namespace ProjectManagement.Domain.Models
{
    /// <summary>
    /// Represents the kanban boards.
    /// </summary>
    public sealed class KanbanBoard
    {
        /// <summary>
        /// Gets or sets the if of the board.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the board.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        public ICollection<ProjectKanbanBoardReference> References { get; set; }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        public ICollection<Cards> Cards { get; set; }
    }
}
