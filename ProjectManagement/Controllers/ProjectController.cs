using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.ProjectKanbanBoards;
using ProjectManagement.Contracts.Projects;

namespace ProjectManagement.Controllers
{
    /// <summary>
    /// Controller for the project endpoints.
    /// </summary>
    [Route("")]
    [ApiController]
    public sealed class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="request"><see cref="CreateProjectRequest"/>.</param>
        /// <returns>Á new project.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Route("/api/project-management/projects")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateProjectResponse), StatusCodes.Status201Created)]
        public IActionResult AddProject([FromBody] CreateProjectRequest request)
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

        /// <summary>
        /// Updates a new project.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="request"><see cref="UpdateProjectRequest"/>.</param>
        /// <returns>The updated project.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Route("/api/project-management/projects/{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(UpdateProjectResponse), StatusCodes.Status200OK)]
        public IActionResult UpdateProject(Guid id, [FromBody] UpdateProjectRequest request)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var project = this._projectService.UpdateProject(id, request.Name, request.Status);

            return Ok(project);
        }

        /// <summary>
        /// Gets a project by the id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <returns>A single project.</returns>
        [Route("/api/project-management/projects/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var project = this._projectService.GetProjectById(id);

            return Ok(project);
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>A list of all projects.</returns>
        [Route("/api/project-management/projects")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProjectsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var projects = this._projectService.GetAllProjects();

            return Ok(projects);
        }

        /// <summary>
        /// Deletes a project by the id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <returns></returns>
        [Route("/api/project-management/projects/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteProject(Guid id)
        {
            this._projectService.DeleteProject(id);

            return NoContent();
        }

        /// <summary>
        /// Sets a reference on a existing board.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="request"><see cref="CreateProjectKanbanBoardReference"/>.</param>
        /// <returns>The reference.</returns>
        [Route("/api/project-management/projects/{id}")]
        [HttpPost]
        public IActionResult AddProjectKanbanBoardReference(
            [FromRoute] Guid id,
            [FromBody] CreateProjectKanbanBoardReference request)
        {
           var reference = _projectService.AddKanbanBoardToProject(id, request.KanbanBoardId);

           return Ok(reference);
        }
    }
}
