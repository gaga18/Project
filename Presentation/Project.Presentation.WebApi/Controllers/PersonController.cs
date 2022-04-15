using Project.Core.Application.DTOs;
using Project.Core.Application.Features.Persons.Commands;
using Project.Core.Application.Features.Persons.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator) =>
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        [HttpGet]
        public async Task<IEnumerable<GetPersonDto>> Get([FromQuery] GetPersonsQuery.Request request)
        {
            var result = await mediator.Send(request);

            Response.Headers.Add("PageIndex", result.PageIndex.ToString());
            Response.Headers.Add("PageSize", result.PageSize.ToString());

            Response.Headers.Add("TotalPages", result.TotalPages.ToString());
            Response.Headers.Add("TotalCount", result.TotalCount.ToString());

            Response.Headers.Add("HasPreviousPage", result.HasPreviousPage.ToString());
            Response.Headers.Add("HasNextPage", result.HasNextPage.ToString());

            return result.Items;
        }

        [HttpGet("{id}")]
        public async Task<GetPersonDto> Get([FromRoute] int id) =>
            await mediator.Send(new GetPersonQuery.Request(id));

        [HttpGet("{personId}/GetFull")]
        public async Task<GetFullPersonDto> GetFull([FromRoute] int personId) => await mediator.Send(new GetFullPersonQuery.Request(personId));

        [HttpPost]
        public async Task Post([FromBody] CreatePersonCommand.Request request) =>
            await mediator.Send(request);

        [HttpPut]
        public async Task Put([FromBody] UpdatePersonCommand.Request request)
        {
            await mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) =>
            await mediator.Send(new DeletePersonCommand.Request(id));
    }
}
