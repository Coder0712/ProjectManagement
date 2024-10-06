using ProjectManagement.Domain.Models;

namespace ProjectManagement.Contracts.Projects
{
    public sealed record GetAllProjectsResponse
    {
        /// <summary>
        /// Gets or sets projects.
        /// </summary>
        public required List<Project> Projects { get; set; }
    }
}
