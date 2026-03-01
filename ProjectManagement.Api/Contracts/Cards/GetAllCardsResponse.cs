using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Contracts.Cards
{
    public sealed record GetAllCardsResponse
    {
        /// <summary>
        /// Gets or sets all cards.
        /// </summary>
        public required List<Card> Cards { get; set; }
    }
}