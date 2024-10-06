using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Contracts.Cards;
using ProjectManagement.Contracts.KanbanBoards;
using ProjectManagement.Contracts.ProjectKanbanBoards;
using ProjectManagement.Contracts.Projects;
using ProjectManagement.Domain.Services;

namespace ProjectManagement.Controllers
{
    [Route("")]
    [ApiController]
    public class ProjectManagementController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IKanbanBoardService _kanbanBoardService;
        private readonly ICardsService _cardService;

        public ProjectManagementController(
            IProjectService projectService,
            IKanbanBoardService kanbanBoardService,
            ICardsService cardService)
        {
            _projectService = projectService;
            _kanbanBoardService = kanbanBoardService;
            _cardService = cardService;
        }

        [Route("/api/project-management/projects")]
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

        [Route("/api/project-management/projects/{id}")]
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

        [Route("/api/project-management/projects")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProjectsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var projects = this._projectService.GetAllProjects();

            return Ok(projects);
        }

        [Route("/api/project-management/projects/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetProjectByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var project = this._projectService.GetProjectById(id);

            return Ok(project);
        }

        [Route("/api/project-management/projects/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            this._projectService.DeleteProject(id);

            return Ok();
        }

        [Route("/api/project-management/projects/{id}")]
        [HttpPost]
        public IActionResult AddProjectKanbanBoardReference(
            [FromRoute] Guid id,
            [FromBody] CreateProjectKanbanBoardReference request)
        {
           var reference = _projectService.AddKanbanBoardToProject(id, request.KanbanBoardId);

           return Ok(reference);
        }

        [Route("/api/project-management/kanban-boards")]
        [HttpPost]
        public IActionResult AddKanbanBoard([FromBody] CreateKanbanBoardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.CreateBoard(request.Name);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpPut]
        public IActionResult UpdateKanbanBoard(
            [FromRoute] Guid id,
            [FromBody] UpdateKanbanBoardRequst request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.UpdateBoard(id, request.Name);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpGet]
        public IActionResult GetKanbanBoardById(
            [FromRoute] Guid id)
        {
            var kanbanBoard = _kanbanBoardService.GetBoard(id);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards")]
        [HttpGet]
        public IActionResult GetKanbanBoards()
        {
            var kanbanBoard = _kanbanBoardService.GetBoards();

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpDelete]
        public IActionResult DeleteKanbanBoardById(
            [FromRoute] Guid id)
        {
            _kanbanBoardService.DeleteBoard(id);

            return NoContent();
        }

        [Route("/api/project-management/cards")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateCardResponse), StatusCodes.Status201Created)]
        public IActionResult AddCard([FromBody] CreateCardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var card = _cardService.Create(
                request.Title,
                request.Description,
                request.Effort,
                request.Status,
                request.Board);

            return Ok(card);
        }

        [Route("/api/project-management/cards/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(UpdateCardResponse), StatusCodes.Status200OK)]
        public IActionResult UpdateCard(
            [FromRoute] Guid id,
            [FromBody] UpdateCardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _cardService.UpdateCard(
                id,
                request.Title,
                request.Description,
                request.Effort,
                request.Status,
                request.Board);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/cards")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProjectsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAllCards()
        {
            var allCards = _cardService.GetAllCards();

            return Ok(allCards);
        }

        [Route("/api/project-management/cards/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetCardByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetCardById([FromRoute] Guid id)
        {
            var card = _cardService.GetCardbyId(id);

            return Ok(card);
        }

        [Route("/api/project-management/cards/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCardById([FromRoute] Guid id)
        {
            _cardService.DeleteCard(id);

            return NoContent();
        }
    }
}
