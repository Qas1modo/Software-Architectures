using MediatR;
using RoomManagementSystem.BL.Queries.RoomQueries;
using RoomManagementSystem.Contracts.Models.RoomModels;
using Microsoft.AspNetCore.Mvc;

namespace RoomManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] int page = -1, [FromQuery] int pageSize = -1)
        {
            var result = await _mediator.Send(new GetRoomsQuery(page, pageSize));
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAvailable([FromQuery] RoomFilterModel filter,
            [FromQuery] int page = -1, [FromQuery] int pageSize = -1)
        {
            var query = new SearchAvailableRoomsQuery(filter, page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var result = await _mediator.Send(new GetRoomQuery(id));
            return Ok(result);
        }
    }

}
