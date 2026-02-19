using ProjectManagement.Domain.Models;

namespace ProjectManagement.Contracts.Projects
{
    public sealed record CreateProjectResponse
    {
        /// <summary>
        /// Gets or sets the project
        /// </summary>
        public required Project Project { get; set; }
    }
}
