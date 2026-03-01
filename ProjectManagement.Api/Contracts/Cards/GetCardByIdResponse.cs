namespace ProjectManagement.Contracts.Cards
{
    using ProjectManagement.Domain.Boards;

    public sealed record GetCardByIdResponse
    {
        /// <summary>
        /// Gets a card.
        /// </summary>
        public required Card Card {  get; set; }
    }
}
