using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.KanbanBoards;
using ProjectManagement.Services;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IKanbanBoardService _kanbanBoardService;

        public ProjectManagementController(
            IProjectService projectService,
            IKanbanBoardService kanbanBoardService)
        {
            _projectService = projectService;
            _kanbanBoardService = kanbanBoardService;
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

        [Route("~/api/project-management/kanban-boards")]
        [HttpPost]
        public IActionResult AddKanbanBoard([FromBody] CreateKanbanBoardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.CreateBoard(request.Name);

            return Ok(kanbanBoard);
        }

        [Route("~/api/project-management/kanban-boards/{id}")]
        [HttpPut]
        public IActionResult UpdateKanbanBoard(
            [FromRoute] Guid id,
            [FromBody] UpdateKanbanBoardRequst request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.UpdateBoard(id, request.Name);

            return Ok(kanbanBoard);
        }

        [Route("~/api/project-management/kanban-boards/{id}")]
        [HttpGet]
        public IActionResult GetKanbanBoardById(
            [FromRoute] Guid id)
        {
            var kanbanBoard = _kanbanBoardService.GetBoard(id);

            return Ok(kanbanBoard);
        }

        [Route("~/api/project-management/kanban-boards")]
        [HttpGet]
        public IActionResult GetKanbanBoards()
        {
            var kanbanBoard = _kanbanBoardService.GetBoards();

            return Ok(kanbanBoard);
        }

        [Route("~/api/project-management/kanban-boards/{id}")]
        [HttpDelete]
        public IActionResult DeleteKanbanBoardById(
            [FromRoute] Guid id)
        {
            _kanbanBoardService.DeleteBoard(id);

            return NoContent();
        }
    }
}
