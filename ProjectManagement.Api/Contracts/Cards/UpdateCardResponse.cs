using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Contracts.Cards
{
    public sealed record UpdateCardResponse
    {
        /// <summary>
        /// Gets the updated card.
        /// </summary>
        public required Card Cards { get; set; }
    }
}
