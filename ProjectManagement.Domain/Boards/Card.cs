using ProjectManagement.Domain.Common;

namespace ProjectManagement.Domain.Boards
{
    /// <summary>
    /// Represents the card entity.
    /// </summary>
    public sealed class Card : Entity, IAuditable
    {
        /// <summary>
        /// Fore EFCore.
        /// </summary>
        protected Card()
        {
        }

        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="effort">The effort.</param>
        /// <param name="status">The status.</param>
        /// <param name="groupId">The group id.</param>
        protected Card(
            Guid id,
            string title,
            string description,
            int effort,
            string status,
            Guid groupId)
            : base(id)
        {
            this.Title = title;
            this.Description = description;
            this.Effort = effort;
            this.Status = status;
            this.GroupId = groupId;
        }

        /// <summary>
        /// The title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The effort.
        /// </summary>
        public int Effort { get; private set; }

        /// <summary>
        /// The status.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// The group.
        /// </summary>
        public Group Group { get; private set; }

        /// <summary>
        /// The group id.
        /// </summary>
        public Guid GroupId { get; private set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; }

        /// <inheritdoc/>
        public DateTime LastModifiedAt { get; }

        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="effort">The effort.</param>
        /// <param name="status">The status.</param>
        /// <param name="groupId">The group id.</param>
        /// <returns>A new card.</returns>
        /// <exception cref="ArgumentNullException">If the parameters are empty or has white space.</exception>
        public static Card Create(
            string title,
            string description,
            int effort,
            string status,
            Guid groupId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title can not be empty."); 
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description), "Description can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentNullException(nameof(status), "Status can not be empty.");
            }

            return new Card()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Effort = effort,
                Status = status,
                GroupId = groupId
            };
        }
    }
}
