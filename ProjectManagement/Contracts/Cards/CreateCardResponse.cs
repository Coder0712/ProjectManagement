namespace ProjectManagement.Contracts.Cards
{
    using ProjectManagement.Domain.Models;

    public sealed record CreateCardResponse
    {
        public required Cards Card { get; set; }
    }
}
