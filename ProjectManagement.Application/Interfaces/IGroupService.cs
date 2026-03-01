using ProjectManagement.Domain.Boards;

namespace ProjectManagement.Application.Interfaces
{
    /// <summary>
    /// Represents a default implementation of a group service.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Creates a group.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="boardId">The board id.</param>
        /// <returns>An instance of <see cref="Group"/>.</returns>
        Group Create(
            string title,
            Guid boardId);

        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns>A list of all groups.</returns>
        List<Group> GetAllGroups();

        /// <summary>
        /// Gets a group.
        /// </summary>
        /// <param name="id">The id of the group.</param>
        /// <returns>An instance of <see cref="Group"/>.</returns>
        Group GetGroupById(Guid id);

        /// <summary>
        /// Delets a group.
        /// </summary>
        /// <param name="id">The id of the group.</param>
        void DeleteGroup(Guid id);

        Group UpdateGroup(Guid id, Card card);
    }
}
