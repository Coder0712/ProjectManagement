using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    /// <summary>
    /// Represents the service for porjects.
    /// </summary>
    public sealed class ProjectService : IProjectService
    {
        List<Project> _projects = new List<Project>();

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
            var project = _projects.FirstOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new NullReferenceException();
            }

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
            return _projects.FirstOrDefault(p => p.Id == id);
        }

        /// <inheritdoc />
        public void DeleteProject(Guid id)
        {
            var project = this._projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new NullReferenceException();
            }

            this._projects.Remove(project);
        }
    }
}