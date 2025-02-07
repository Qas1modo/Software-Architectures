using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomManagementSystem.BL;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.BL.Queries.ReservationQueries;
using SharedKernel.Messages;
using Wolverine;

namespace RoomManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMessageBus _messageBus;

        public ReservationsController(IMediator mediator, IMessageBus messageBus)
        {
            _mediator = mediator;
            _messageBus = messageBus;
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
        public async Task<IActionResult> CheckIn(int id, string firstName, string lastName, string email)
        {
            var result = await _mediator.Send(new CheckInCommand(id));
            await _messageBus.PublishAsync(new GuestCheckedInMessage(Guid.NewGuid(), id, firstName, lastName, email));
            return Ok(result);
        }

        [HttpPut("check-out/{id}")]
        public async Task<IActionResult> CheckOut(int id, Guid guestGuid, string firstName, string lastName, string email)
        {
            var result = await _mediator.Send(new CheckOutCommand(id));
            await _messageBus.PublishAsync(new GuestCheckedOutMessage(guestGuid, id, firstName, lastName, email));

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
