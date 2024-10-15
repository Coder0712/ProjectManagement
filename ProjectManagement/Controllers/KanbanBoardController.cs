using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.Cards;
using ProjectManagement.Contracts.KanbanBoards;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("")]
    [ApiController]
    public sealed class KanbanBoardController : ControllerBase
    {
        private readonly IKanbanBoardService _kanbanBoardService;

        public KanbanBoardController(IKanbanBoardService kanbanBoardService)
        {
            _kanbanBoardService = kanbanBoardService;
        }

        [Route("/api/project-management/kanban-boards")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateKanbanBoardResponse), StatusCodes.Status201Created)]
        public IActionResult AddKanbanBoard([FromBody] CreateKanbanBoardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.CreateBoard(request.Name);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(UpdateKanbanBoardResponse), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(GetKanbanBoardByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetKanbanBoardById(
            [FromRoute] Guid id)
        {
            var kanbanBoard = _kanbanBoardService.GetBoard(id);

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards")]
        [HttpGet]
        [ProducesResponseType(typeof(GetKanbanBoardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetKanbanBoards()
        {
            var kanbanBoard = _kanbanBoardService.GetBoards();

            return Ok(kanbanBoard);
        }

        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteKanbanBoardById(
            [FromRoute] Guid id)
        {
            _kanbanBoardService.DeleteBoard(id);

            return NoContent();
        }
    }
}
