using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Application.DTOs;
using Project.Core.Application.Features.PersonPerson.Commands;
using Project.Core.Application.Features.PersonPersons.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonPersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonPersonController(IMediator mediator) =>
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task Post([FromForm] CreatePersonPersonCommand.Request request) =>
            await mediator.Send(request);

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await mediator.Send(new DeletePersonPersonCommand.Request(id));

    }
}
