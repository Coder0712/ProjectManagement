namespace ProjectManagement.Contracts.Cards
{
    /// <summary>
    /// Represents a request to update a card
    /// </summary>
    public sealed record UpdateCardRequest
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public required string Description { get; init; }

        /// <summary>
        /// Gets the effort.
        /// </summary>
        public required int Effort { get; init; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public required string Status { get; init; }

        /// <summary>
        /// Gets the board.
        /// </summary>
        public required Guid Board { get; init; }
    }
}
