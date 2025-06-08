using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.Cards;
using ProjectManagement.Contracts.Projects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    /// <summary>
    /// Controller for the card endpoints.
    /// </summary>
    [Route("")]
    [ApiController]
    public sealed class CardController : ControllerBase
    {
        private readonly ICardsService _cardService;

        public CardController(ICardsService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Creates a new card.
        /// </summary>
        /// <param name="request"><see cref="CreateCardRequest"/>.</param>
        /// <returns>A new card.</returns>
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

        /// <summary>
        /// Updates a card.
        /// </summary>
        /// <param name="id">The id of the card.</param>
        /// <param name="request"><see cref="UpdateCardRequest"/>.</param>
        /// <returns>An updated card.</returns>
        [Route("/api/project-management/cards/{id}")]
        [HttpPatch]
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

        /// <summary>
        /// Gets a card by the id.
        /// </summary>
        /// <param name="id">The id of the card.</param>
        /// <returns>A single card.</returns>
        [Route("/api/project-management/cards/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetCardByIdResponse), StatusCodes.Status200OK)]
        public IActionResult GetCardById([FromRoute] Guid id)
        {
            var card = _cardService.GetCardbyId(id);

            return Ok(card);
        }

        /// <summary>
        /// Gets all cards.
        /// </summary>
        /// <returns>A list with all cards.</returns>
        [Route("/api/project-management/cards")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProjectsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAllCards()
        {
            var allCards = _cardService.GetAllCards();

            return Ok(allCards);
        }

        /// <summary>
        /// Deletes a card by the id.
        /// </summary>
        /// <param name="id">The id of the card.</param>
        /// <returns>No content.</returns>
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
