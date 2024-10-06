using ProjectManagement.Domain.Models;

namespace ProjectManagement.Domain.Services
{
    /// <summary>
    /// A default implementation of a project service.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="description">The description of a project.</param>
        /// <param name="status">The status of the project.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>A new project.</returns>
        Project CreateProject(string name, string description, string status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="name">The name of the project.</param>
        /// <param name="status">The status of the project.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The existing project with other name or other status.</returns>
        Project UpdateProject(Guid id, string name, string status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a project.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        void DeleteProject(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>A list with all projects.</returns>
        List<Project> GetAllProjects();

        /// <summary>
        /// Gets a project by its id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <returns>A single project.</returns>
        Project GetProjectById(Guid id);

        /// <summary>
        /// Creates a reference from a kanban board to a project.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <param name="kanbanBoardId">The kanban board id.</param>
        /// <returns>A project kanban board reference.</returns>
        ProjectKanbanBoardReference AddKanbanBoardToProject(Guid projectId, Guid kanbanBoardId, CancellationToken cancellationToken = default);
    }
}
