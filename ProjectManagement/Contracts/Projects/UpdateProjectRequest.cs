namespace ProjectManagement.Contracts.Projects
{
    public sealed record UpdateProjectRequest
    {
        public string? Name { get; set; }

        public string? Status { get; set; }
    }
}
