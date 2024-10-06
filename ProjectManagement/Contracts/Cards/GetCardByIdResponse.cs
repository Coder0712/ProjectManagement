namespace ProjectManagement.Contracts.Cards
{
    using ProjectManagement.Domain.Models;

    public sealed record GetCardByIdResponse
    {
        /// <summary>
        /// Gets a card.
        /// </summary>
        public required Cards Card {  get; set; }
    }
}
