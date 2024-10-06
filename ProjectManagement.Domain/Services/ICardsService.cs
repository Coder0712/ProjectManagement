using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Services
{
    /// <summary>
    /// A default implementation of a card service.
    /// </summary>
    public interface ICardsService
    {
        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="description">The description.</param>
        /// <param name="effort">The effort.</param>
        /// <param name="status">The status.</param>
        /// <param name="boardId">The board id.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>A new instance of type <see cref="Cards"/>.</returns>
        Cards Create(
            string title,
            string description,
            int effort,
            string status,
            Guid boardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a card.
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="description">The description.</param>
        /// <param name="effort">The effort.</param>
        /// <param name="status">The status.</param>
        /// <param name="boardId">The board id.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>A updated instance of type <see cref="Cards"/>.</returns>
        Cards UpdateCard(
            Guid CardId,
            string title,
            string description,
            int effort,
            string status,
            Guid boardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a card.
        /// </summary>
        /// <param name="cardId">The card id.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        void DeleteCard(Guid cardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all cards.
        /// </summary>
        /// <returns>A list with all cards.</returns>
        List<Cards> GetAllCards();

        /// <summary>
        /// Gets a card by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Cards GetCardbyId(Guid id);
    }
}
