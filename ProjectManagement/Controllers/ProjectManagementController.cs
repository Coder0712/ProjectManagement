using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Contracts;
using ProjectManagement.Models;
using ProjectManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectManagementController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public void Post([FromBody] CreateProjectRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            this._projectService.CreateProject(
                request.Name,
                request.Description,
                request.Status);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] UpdateProjectRequest request)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            this._projectService.UpdateProject(id, request.Name, request.Status);
        }
        
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return this._projectService.GetAllProjects();
        }

        [HttpGet("{id}")]
        public Project Get(Guid id)
        {
            return this._projectService.GetProjectById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this._projectService.DeleteProject(id);
        }
    }
}
