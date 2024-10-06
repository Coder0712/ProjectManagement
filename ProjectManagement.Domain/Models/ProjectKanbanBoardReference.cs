namespace ProjectManagement.Domain.Models
{
    /// <summary>
    /// Represents a reference from a project to a kanban board.
    /// </summary>
    public sealed class ProjectKanbanBoardReference
    {
        /// <summary>
        /// Gets or sets the id of the reference.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the id of the project.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the id of the kanban board.
        /// </summary>
        public Guid KanbanBoardId { get; set; }
    }
}
