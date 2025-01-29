using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomManagementSystem.BL;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.BL.Queries.ReservationQueries;

namespace RoomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelReservationCommand(id));
            return Ok(result);
        }

        [HttpPut("check-in/{id}")]
        public async Task<IActionResult> CheckIn(int id)
        {
            var result = await _mediator.Send(new CheckInCommand(id));
            return Ok(result);
        }

        [HttpPut("check-out/{id}")]
        public async Task<IActionResult> CheckOut(int id)
        {
            var result = await _mediator.Send(new CheckOutCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetReservationQuery(id));
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(int , int pageSize)
        //{
        //    var result = await _mediator.Send(new GetReservationsQuery());
        //    return Ok(result);
        //}
    }

}
