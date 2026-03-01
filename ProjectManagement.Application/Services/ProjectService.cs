using ProjectManagement.Domain.Common;
using ProjectManagement.Domain.Projects;

namespace ProjectManagement.Application.Services
{
    /// <summary>
    /// Represents the service for porjects.
    /// </summary>
    public sealed class ProjectService
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
        public Project UpdateProject(Guid id, string name, string status, CancellationToken cancellationToken = default)
        {
            var project = _dbContext.Project.FirstOrDefault(p => p.Id == id) 
                ?? throw new NullReferenceException();

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
    }
}