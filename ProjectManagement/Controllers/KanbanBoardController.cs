using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.KanbanBoards;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    /// <summary>
    /// Controller for the kanban board endpoints.
    /// </summary>
    [Route("")]
    [ApiController]
    public sealed class KanbanBoardController : ControllerBase
    {
        private readonly IKanbanBoardService _kanbanBoardService;

        public KanbanBoardController(IKanbanBoardService kanbanBoardService)
        {
            _kanbanBoardService = kanbanBoardService;
        }

        /// <summary>
        /// Creates a kanban board.
        /// </summary>
        /// <param name="request"><see cref="CreateKanbanBoardRequest"/>.</param>
        /// <returns>A kanban baord.</returns>
        [Route("/api/project-management/kanban-boards")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateKanbanBoardResponse), StatusCodes.Status201Created)]
        public IActionResult AddKanbanBoard([FromBody] CreateKanbanBoardRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.CreateBoard(request.Name);

            return Ok(kanbanBoard);
        }

        /// <summary>
        /// Updates a kanban board.
        /// </summary>
        /// <param name="id">the id of the kanban board.</param>
        /// <param name="request"><see cref="UpdateKanbanBoardRequst"/>.</param>
        /// <returns>The updated kanban board.</returns>
        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(UpdateKanbanBoardResponse), StatusCodes.Status200OK)]
        public IActionResult UpdateKanbanBoard(
            [FromRoute] Guid id,
            [FromBody] UpdateKanbanBoardRequst request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var kanbanBoard = _kanbanBoardService.UpdateBoard(id, request.Name);

            return Ok(kanbanBoard);
        }

        /// <summary>
        /// Gets a kanban board by the id.
        /// </summary>
        /// <param name="id">The id of the kanban board.</param>
        /// <returns>A single kanban board.</returns>
        [Route("/api/project-management/kanban-boards/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetKanbanBoardByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetKanbanBoardById(
            [FromRoute] Guid id)
        {
            var kanbanBoard = _kanbanBoardService.GetBoard(id);

            return Ok(kanbanBoard);
        }

        /// <summary>
        /// Gets all kanban boards.
        /// </summary>
        /// <returns>A list of kanban boards.</returns>
        [Route("/api/project-management/kanban-boards")]
        [HttpGet]
        [ProducesResponseType(typeof(GetKanbanBoardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetKanbanBoards()
        {
            var kanbanBoard = _kanbanBoardService.GetBoards();

            return Ok(kanbanBoard);
        }

        /// <summary>
        /// Deletes a kanban board.
        /// </summary>
        /// <param name="id">The id of the kanban board.</param>
        /// <returns>No content.</returns>
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
