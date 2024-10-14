using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.Cards;
using ProjectManagement.Contracts.Projects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("")]
    [ApiController]
    public sealed class CardController : ControllerBase
    {
        private readonly ICardsService _cardService;

        public CardController(ICardsService cardService)
        {
            _cardService = cardService;
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
