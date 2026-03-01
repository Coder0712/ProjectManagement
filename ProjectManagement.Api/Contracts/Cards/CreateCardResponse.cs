using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Contracts.Cards
{
    public sealed record CreateCardResponse
    {
        public required Card Card { get; set; }
    }
}
