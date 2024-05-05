using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Contracts;
using ProjectManagement.Services;

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

        [Route("~/api/project-management/projects")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateProjectResponse), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CreateProjectRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var project = this._projectService.CreateProject(
                request.Name,
                request.Description,
                request.Status);

            return CreatedAtAction("GetById", new { id = project.Id }, project);
            
        }

        [Route("~/api/project-management/projects/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(UpdateProjectResponse), StatusCodes.Status200OK)]
        public IActionResult Put(Guid id, [FromBody] UpdateProjectRequest request)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var project = this._projectService.UpdateProject(id, request.Name, request.Status);

            return Ok(project);
        }

        [Route("~/api/project-management/projects")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProjectsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var projects = this._projectService.GetAllProjects();

            return Ok(projects);
        }

        [Route("~/api/project-management/projects/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var project = this._projectService.GetProjectById(id);

            return Ok(project);
        }

        [Route("~/api/project-management/projects/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            this._projectService.DeleteProject(id);

            return Ok();
        }
    }
}
