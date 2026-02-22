using ProjectManagement.Domain.Common;

namespace ProjectManagement.Domain.Projects
{
    /// <summary>
    /// The project aggregate.
    /// </summary>
    public sealed class Project : AggregateRoot
    {
        /// <summary>
        /// For EFCore.
        /// </summary>
        protected Project()
        {
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="status">The status.</param>
        protected Project(
            Guid id,
            string name,
            string description,
            string status)
            : base(id)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Gets the board id.
        /// </summary>
        public BoardId? BoardId { get; private set; }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="description">The description of the project.</param>
        /// <param name="status">The status of the project.</param>
        /// <param name="boardId">The board id of the project.</param>
        /// <returns>A new project.</returns>
        public static Project Create(
            string name,
            string description,
            string status,
            BoardId boardId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name can not be empty");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Description can not be empty");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentNullException(nameof(status), "Status can not be empty.");
            }

            return new Project()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = status
            };
        }

        /// <summary>
        /// Adds or change the board id.
        /// </summary>
        /// <param name="boardId">The new board id.</param>
        /// <returns>The updated project.</returns>
        public Project AddOrChangeBoard(BoardId boardId)
        {
            this.BoardId = boardId;
            Modify();
            return this;
        }

        /// <summary>
        /// Removes the board.
        /// </summary>
        /// <returns>The updated project.</returns>
        public Project RemoveBoard()
        {
            this.BoardId = null;
            Modify();
            return this;
        }

        /// <summary>
        /// Change the name of the project.
        /// </summary>
        /// <param name="name">The new name.</param>
        /// <returns>The updated project.</returns>
        public Project UdpateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name can not be empty");
            }

            this.Name = name;
            Modify();
            return this;
        }

        /// <summary>
        /// Change the description of the project.
        /// </summary>
        /// <param name="name">The new description.</param>
        /// <returns>The updated project.</returns>
        public Project UpdateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Description can not be empty");
            }

            this.Description = description;
            Modify();
            return this;
        }

        /// <summary>
        /// Change the status of the project.
        /// </summary>
        /// <param name="name">The new status.</param>
        /// <returns>The updated project.</returns>
        public Project UpdateStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentNullException(nameof(status), "Status can not be empty.");
            }

            this.Status = status;
            Modify();
            return this;
        }
    }
}
