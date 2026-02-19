namespace ProjectManagement.Contracts.Projects
{
    /// <summary>
    /// Represents a request to create a 
    /// </summary>
    public sealed record CreateProjectRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public required string Status { get; set; }
    }
}
