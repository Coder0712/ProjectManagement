using ProjectManagement.Application.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Common;

namespace ProjectManagement.Application.Services
{
    /// <summary>
    /// The cards service.
    /// </summary>
    public sealed class CardsService : ICardsService
    {
        private readonly IDbContext _dbContext;

        public CardsService(IDbContext dbContext)
            => _dbContext = dbContext;

        public Cards Create(
            string title,
            string description,
            int effort,
            string status,
            Guid boardId,
            CancellationToken cancellationToken = default)
        {
            var card = new Cards
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Effort = effort,
                Status = status,
                BoardId = boardId,
            };

            _ = _dbContext.Cards.Add(card);
            _ = _dbContext.SaveChangesAsync(cancellationToken);

            return card;
        }

        public void DeleteCard(
            Guid cardId,
            CancellationToken cancellationToken = default)
        {
            var card = _dbContext.Cards.SingleOrDefault(p => p.Id == cardId)
                ?? throw new NullReferenceException();

            _dbContext.Cards.Remove(card);
            _dbContext.SaveChangesAsync(cancellationToken);
        }

        public List<Cards> GetAllCards()
        {
            return _dbContext.Cards.ToList();
        }

        public Cards GetCardbyId(Guid id)
        {
            var card = _dbContext.Cards.SingleOrDefault(p => p.Id == id);

            return card is null
               ? throw new NullReferenceException()
               : card;
        }

        public Cards UpdateCard(
            Guid CardId,
            string title,
            string description,
            int effort,
            string status,
            Guid boardId,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(title);
            ArgumentNullException.ThrowIfNull(description);
            ArgumentNullException.ThrowIfNull(status);

            var card = _dbContext.Cards.SingleOrDefault(p => p.Id == CardId)
                ?? throw new NullReferenceException();

            card.Title = title;
            card.Description = description;
            card.Effort = effort;
            card.Status = status;
            card.BoardId = boardId;

            _dbContext.Cards.Update(card);
            _dbContext.SaveChangesAsync(cancellationToken);

            return card;
        }
    }
}
