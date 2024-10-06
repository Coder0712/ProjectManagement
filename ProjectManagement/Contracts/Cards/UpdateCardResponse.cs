namespace ProjectManagement.Contracts.Cards
{
    using ProjectManagement.Domain.Models;

    public sealed record UpdateCardResponse
    {
        /// <summary>
        /// Gets the updated card.
        /// </summary>
        public required Cards Cards { get; set; }
    }
}
