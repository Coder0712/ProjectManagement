using ProjectManagement.Models;

namespace ProjectManagement.Contracts.Projects
{
    public sealed record UpdateProjectResponse
    {
        /// <summary>
        /// Gets or sets the updated project.
        /// </summary>
        public required Project Project { get; set; }
    }
}
