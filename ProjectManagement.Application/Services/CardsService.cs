using ProjectManagement.Domain.Boards;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Application.Services
{
    /// <summary>
    /// The Card service.
    /// </summary>
    public sealed class CardService
    {
        private readonly IDbContext _dbContext;

        public CardService(IDbContext dbContext)
            => _dbContext = dbContext;

        public void DeleteCard(
            Guid cardId,
            CancellationToken cancellationToken = default)
        {
            var card = _dbContext.Card.SingleOrDefault(p => p.Id == cardId)
                ?? throw new NullReferenceException();

            _dbContext.Card.Remove(card);
            _dbContext.SaveChangesAsync(cancellationToken);
        }

        public List<Card> GetAllCard()
        {
            return _dbContext.Card.ToList();
        }

        public Card GetCardbyId(Guid id)
        {
            var card = _dbContext.Card.SingleOrDefault(p => p.Id == id);

            return card is null
               ? throw new NullReferenceException()
               : card;
        }
    }
}
