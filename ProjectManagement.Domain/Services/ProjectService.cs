using ProjectManagement.Models;
using ProjectManagement.Domain;


namespace ProjectManagement.Services
{
    /// <summary>
    /// Represents the service for porjects.
    /// </summary>
    public sealed class ProjectService : IProjectService
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Initialize a new object of type <see cref="ProjectService"/>.>
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public ProjectService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public Project CreateProject(string name, string description, string status, CancellationToken cancellationToken = default)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = status
            };

            _dbContext.Project.Add(project);
            _dbContext.SaveChangesAsync(cancellationToken);

            return project;
        }

        /// <inheritdoc />
        public Project UpdateProject(Guid id, string name, string status, CancellationToken cancellationToken = default)
        {
            var project = _dbContext.Project.FirstOrDefault(p => p.Id == id) 
                ?? throw new NullReferenceException();
            
            if (name is null)
            {
                project.Status = status;
            }
            else
            {
                project.Name = name;
            }

            _dbContext.Project.Update(project);
            _dbContext.SaveChangesAsync(cancellationToken);

            return project;
        }

        /// <inheritdoc />
        public List<Project> GetAllProjects()
        {
            return this._dbContext.Project.ToList();
        }

        /// <inheritdoc />
        public Project GetProjectById(Guid id)
        {
            return _dbContext.Project.Single(p => p.Id == id);
        }

        /// <inheritdoc />
        public void DeleteProject(Guid id, CancellationToken cancellationToken = default)
        {
            var project = _dbContext.Project.SingleOrDefault(p => p.Id == id) 
                ?? throw new NullReferenceException();
            
            _dbContext.Project.Remove(project);
            _dbContext.SaveChangesAsync(cancellationToken);
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
            var project = _dbContext.Project.SingleOrDefault(p => p.Id == projectId) 
                ?? throw new NullReferenceException();

            var reference = new ProjectKanbanBoardReference
            {
                ProjectId = projectId,
                KanbanBoardId = kanbanBoardId,
            };

            _dbContext.ProjectKanbanBoardReferences.Add(reference);

            return reference;
        }
    }
}