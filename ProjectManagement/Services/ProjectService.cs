using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    /// <summary>
    /// Represents the service for porjects.
    /// </summary>
    public sealed class ProjectService : IProjectService
    {
        List<Project> _projects = [];
        List<ProjectKanbanBoardReference> _references = [];

        /// <inheritdoc />
        public Project CreateProject(string name, string description, string status)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = status
            };

            this._projects.Add(project);

            return project;
        }

        public Project UpdateProject(Guid id, string name, string status)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id) 
                ?? throw new NullReferenceException();
            
            if (name is null)
            {
                project.Status = status;
            }
            else
            {
                project.Name = name;
            }

            return project;
        }

        /// <inheritdoc />
        public List<Project> GetAllProjects()
        {
            return this._projects;
        }

        /// <inheritdoc />
        public Project GetProjectById(Guid id)
        {
            return _projects.Single(p => p.Id == id);
        }

        /// <inheritdoc />
        public void DeleteProject(Guid id)
        {
            var project = this._projects.SingleOrDefault(p => p.Id == id) 
                ?? throw new NullReferenceException();
            
            this._projects.Remove(project);
        }

        /// <summary>
        /// Creates a new project kanban board reference.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <param name="kanbanBoardId">The kanban board id.</param>
        /// <returns>A project kanban board reference object.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public ProjectKanbanBoardReference AddKanbanBoardToProject(Guid projectId, Guid kanbanBoardId)
        {
            var project = _projects.SingleOrDefault(p => p.Id == projectId) 
                ?? throw new NullReferenceException();

            var reference = new ProjectKanbanBoardReference
            {
                ProjectId = projectId,
                KanbanBoardId = kanbanBoardId,
            };

            _references.Add(reference);

            return reference;
        }
    }
}