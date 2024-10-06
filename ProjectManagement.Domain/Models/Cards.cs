namespace ProjectManagement.Domain.Models
{
    /// <summary>
    /// Represents a card on the board
    /// </summary>
    public sealed class Cards
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the effort.
        /// </summary>
        public int Effort { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the board id.
        /// </summary>
        public Guid BoardId { get; set; }
    }
}
