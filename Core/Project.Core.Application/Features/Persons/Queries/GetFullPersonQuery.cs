using AutoMapper;
using MediatR;
using Project.Core.Application.DTOs;
using Project.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.Persons.Queries
{
    public class GetFullPersonQuery
    {
        public class Request : IRequest<GetFullPersonDto>
        {
            public int PersonId { get; private set; }

            public Request(int PersonId) => this.PersonId = PersonId;
        }

        public class Handler : IRequestHandler<Request, GetFullPersonDto>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }

            public async Task<GetFullPersonDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var person = await unit.PersonRepository.ReadAsync(request.PersonId);

                if (person == null)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                var fullPerson = mapper.Map<GetFullPersonDto>(person);

                foreach (var item in fullPerson.PersonPersons)
                {
                    var RelatedPerson = await unit.PersonRepository.ReadAsync(item.RelatedPersonId);
                    item.RelatedPerson = mapper.Map<GetPersonDto>(RelatedPerson);
                }


                return await Task.FromResult(fullPerson);
            }
        }
    }
}
