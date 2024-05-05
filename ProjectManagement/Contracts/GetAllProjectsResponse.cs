using ProjectManagement.Models;

namespace ProjectManagement.Contracts
{
    public sealed record GetAllProjectsResponse
    {
        /// <summary>
        /// Gets or sets projects.
        /// </summary>
        public required List<Project> Projects { get; set; }
    }
}
