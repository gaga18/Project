using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Application.DTOs;
using Project.Core.Application.Features.PersonReport.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReportController(IMediator mediator) =>
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        [HttpGet]
        public async Task<List<GetPersonReportDto>> Get() =>
            await mediator.Send(new GetPersonReportQuery.Request());
    }
}
