namespace ProjectManagement.Api.Contracts.Groups
{
    public class AddGroupRequest
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the board id.
        /// </summary>
        public Guid BoardId { get; init; }
    }
}
