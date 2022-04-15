using AutoMapper;
using MediatR;
using Project.Core.Application.DTOs;
using Project.Core.Application.Interfaces;
using Project.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.PersonReport.Queries
{
    public class GetPersonReportQuery
    {
        public class Request : IRequest<List<GetPersonReportDto>>
        {
        }

        public class Handler : IRequestHandler<Request, List<GetPersonReportDto>>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }

            public async Task<List<GetPersonReportDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var PersonPersons = await unit.PersonPersonRepository.ReadAsync();

                var report = PersonPersons.ToList().GroupBy(c => new
                {
                    c.PersonId,
                    c.RelatedType,
                })
                .Select(gcs => new GetPersonReportDto()
                {
                    PersonId = gcs.Key.PersonId,
                    Type = gcs.Key.RelatedType == RelatedType.Colleague ? "კოლეგა" : gcs.Key.RelatedType == RelatedType.Relative ? "ნათესავი" : "სხვა",
                    Count = gcs.Count()
                }).ToList();

                return await Task.FromResult(report);
            }
        }
    }
}
