namespace ProjectManagement.Contracts.Cards
{
    using ProjectManagement.Domain.Models;

    public sealed record GetAllCardsResponse
    {
        /// <summary>
        /// Gets or sets all cards.
        /// </summary>
        public required List<Cards> Cards { get; set; }
    }
}