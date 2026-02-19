using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Contracts.Groups;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Contracts.Cards;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly ICardsService _cardsService;

        public GroupController(
            IGroupService groupService,
            ICardsService cardsService)
        {
            this._groupService = groupService;
            this._cardsService = cardsService;
        }


        // POST api/<GroupController>
        [Route("/api/project-management/groups")]
        [HttpPost]
        public IActionResult AddGroup([FromBody] AddGroupRequest request)
        {
            var group = this._groupService.Create(request.Title, request.BoardId);

            return Ok(group);
        }

        // GET: api/<GroupController>
        [Route("/api/project-management/groups")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._groupService.GetAllGroups());
        }

        // GET api/<GroupController>/
        [Route("/api/project-management/groups/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(this._groupService.GetGroupById(id));
        }

        // PUT api/<GroupController>/
        [Route("/api/project-management/groups/{id}")]
        [HttpPut]
        public IActionResult AddCard([FromRoute] Guid id, [FromBody] CreateCardRequest card)
        {
            var createdCard = this._cardsService.Create(card.Title, card.Description, card.Effort, card.Status, id);

            return Ok(this._groupService.UpdateGroup(id, createdCard));
        }

        // DELETE api/<GroupController>/5
        [Route("/api/project-management/groups/{id}")]
        [HttpDelete]
        public void Delete([FromRoute] Guid id)
        {
            this._groupService.DeleteGroup(id);
        }
    }
}
