using ProjectManagement.Domain.Common;

namespace ProjectManagement.Domain.Boards
{
    /// <summary>
    /// Represents the group entity.
    /// </summary>
    public sealed class Group : Entity, IAuditable
    {
        private List<Card> _cards = new List<Card>();

        /// <summary>
        /// For EFCore.
        /// </summary>
        protected Group()
        {
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="boardId">The board id.</param>
        protected Group(
            Guid id,
            string title,
            Guid boardId)
            : base(id)
        {
            BoardId = boardId;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the board.
        /// </summary>
        public Board Board { get; }

        /// <summary>
        /// Gets the board id.
        /// </summary>
        public Guid BoardId { get; init; }

        /// <summary>
        /// Gets the cards.
        /// </summary>
        public IReadOnlyCollection<Card> Cards => _cards;

        /// <inheritdoc/>
        public DateTime CreatedAt { get; }

        /// <inheritdoc/>
        public DateTime LastModifiedAt { get; }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="boardId">The board id.</param>
        /// <returns>A new group.</returns>
        /// <exception cref="ArgumentNullException">If the title is empty or has white space.</exception>
        public static Group Create(
            string title,
            Guid boardId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be empty.");
            }

            return new Group()
            {
                Id = Guid.NewGuid(),
                Title = title,
                BoardId = boardId
            };
        }

        /// <summary>
        /// Updates the title.
        /// </summary>
        /// <param name="title">The new title.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the title is empty or has white space.</exception>
        public Group UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be empty.");
            }

            this.Title = title;
            return this;
        }

        /// <summary>
        /// Adds a card to the group.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <exception cref="ArgumentNullException">If the card is empty.</exception>
        public void AddCard(Card card)
        {
            if (card is null)
            {
                throw new ArgumentNullException(nameof(card), "Card can not be empty.");
            }

            this._cards.Add(card);
        }
    }
}