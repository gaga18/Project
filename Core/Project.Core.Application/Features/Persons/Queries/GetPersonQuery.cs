using AutoMapper;
using Project.Core.Application.DTOs;
using Project.Core.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.Persons.Queries
{
    public class GetPersonQuery
    {
        public class Request : IRequest<GetPersonDto>
        {
            public int PersonId { get; private set; }

            public Request(int PersonId) => this.PersonId = PersonId;
        }

        public class Handler : IRequestHandler<Request, GetPersonDto>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }

            public async Task<GetPersonDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var person = await unit.PersonRepository.ReadAsync(request.PersonId);
                if (person == null)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                return await Task.FromResult(mapper.Map<GetPersonDto>(person));
            }
        }
    }
}
