using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers
{
    public sealed class GuestController : ApiController
    {
        public GuestController(IMediator mediator)
            : base(mediator)
        {
        }

        //[HttpGet(ApiRoutes.Guest.Post)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Post(CreateGuestModel groupEventId) =>
        //    await Maybe<TODOQuery>
        //        .From(new TODOQueryEvent(groupEventId))
        //        .Bind(query => Mediator.Send(query))
        //        .Match(Ok, NotFound);
    }
}
