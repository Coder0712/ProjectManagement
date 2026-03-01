using ProjectManagement.Domain.Projects;

namespace ProjectManagement.Contracts.Projects
{
    public sealed record GetProjectByIdResponse
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public required Project Project { get; set; }
    }
}
