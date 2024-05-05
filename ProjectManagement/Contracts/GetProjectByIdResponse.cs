using ProjectManagement.Models;

namespace ProjectManagement.Contracts
{
    public sealed record GetProjectByIdResponse
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public required Project Project { get; set; }
    }
}
