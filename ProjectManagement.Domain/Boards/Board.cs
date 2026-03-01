using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Projects;

namespace ProjectManagement.Domain.Boards
{
    /// <summary>
    /// The board aggregate.
    /// </summary>
    public sealed class Board : AggregateRoot, IAuditable
    {
        private readonly List<Group> _groups = new List<Group>();

        /// <summary>
        /// For EfCore.
        /// </summary>
        protected Board()
        {
        }

        /// <summary>
        /// Creates a new board.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="projectId">The project id.</param>
        protected Board(
            Guid id,
            string title,
            Guid projectId)
            : base(id)
        {
            Title = title;
            ProjectId = projectId;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the groups.
        /// </summary>
        public IReadOnlyCollection<Group> Groups => _groups;

        /// <summary>
        /// Gets the project id.
        /// </summary>
        public Guid ProjectId { get; init; }

        /// <summary>
        /// Gets the project.
        /// </summary>
        public Project Project { get; init; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; }

        /// <inheritdoc/>
        public DateTime LastModifiedAt { get; }

        /// <summary>
        /// Creates a new board.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="projectId">The project id.</param>
        /// <returns>The new board.</returns>
        /// <exception cref="ArgumentNullException">If the title is empty or has white space.</exception>
        public static Board Create(
            string title,
            Guid projectId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be empty.");
            }

            return new Board()
            {
                Id = Guid.NewGuid(),
                Title = title,
                ProjectId = projectId
            };
        }

        /// <summary>
        /// Updates the title.
        /// </summary>
        /// <param name="title">The new title.</param>
        /// <returns>The board with the new title.</returns>
        /// <exception cref="ArgumentNullException">If the title is empty or has white space.</exception>
        public Board UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be empty.");
            }

            this.Title = title;
            return this;
        }

        /// <summary>
        /// Creates a group.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="boardId">The board id.</param>
        /// <returns>The board with the groups.</returns>
        /// <exception cref="ArgumentException">If the parameters are empty or has white space.</exception>
        public Board CreateGroup(string title, Guid boardId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(nameof(title), "Title can not be null");
            }

            if(boardId == Guid.Empty)
            {
                throw new ArgumentException(nameof(boardId), "Board id can not be empty");
            }

            _groups.Add(Group.Create(title, boardId));

            return this;
        }

        /// <summary>
        /// Removes a group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>The board with the groups.</returns>
        /// <exception cref="Exception">If the group has cards.</exception>
        public Board RemoveGroup(Group group)
        {
            // Group darf keine Cards enthalten beim löschen.
            if(_groups.Any(g => g.Cards.Count > 0))
            {
                throw new Exception("Group can not be removed because it has cards.");
            }

            this._groups.Remove(group);
            return this;
        }

        /// <summary>
        /// Adds a card to the group.
        /// </summary>
        /// <param name="groupId">The group id.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="effort">The effort.</param>
        /// <param name="status">The status.</param>
        /// <returns>The board with the groups and cards.</returns>
        /// <exception cref="Exception">If the group was not found.</exception>
        public Board AddCardToGroup(
            Guid groupId,
            string title,
            string description,
            int effort,
            string status)
        {
            var group = this.Groups.FirstOrDefault(g => g.Id == groupId);

            if (group == null)
            {
                throw new Exception("Group not found.");
            }

            var card = Card.Create(title, description, effort, status, groupId);

            group.AddCard(card);

            return this;
        }
    }
}
