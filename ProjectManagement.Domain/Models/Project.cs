namespace ProjectManagement.Domain.Models
{
    /// <summary>
    /// Represents a project.
    /// </summary>
    public sealed class Project
    {
        /// <summary>
        /// Gets or sets teh id of a project.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of a project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of a project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status of a project.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        public ICollection<ProjectKanbanBoardReference> References { get; set; }
    }
}
