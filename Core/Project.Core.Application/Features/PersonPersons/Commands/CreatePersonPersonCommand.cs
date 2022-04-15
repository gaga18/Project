using AutoMapper;
using MediatR;
using Project.Core.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Project.Core.Domain.Entities;
using Project.Core.Domain.Enums;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.PersonPersons.Commands
{
    public class CreatePersonPersonCommand
    {
        public class Request : IRequest
        {
            public int PersonId { get; set; }
            public int RelatedPersonId { get; set; }
            public RelatedType RelatedType { get; set; }
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var PersonId = await unit.PersonRepository.CheckAsync(x => x.Id == request.PersonId);
                if (!PersonId)
                    throw new EntityNotFoundException("ფიზიკური პირი ვერ მოიძებნა");

                var RelatedPersonId = await unit.PersonRepository.CheckAsync(x => x.Id == request.RelatedPersonId);
                if (!RelatedPersonId)
                    throw new EntityNotFoundException("დაკავშირებული ფიზიკური პირი ვერ მოიძებნა");

                var personPerson = mapper.Map<Domain.Entities.PersonPerson>(request);
 
                await unit.PersonPersonRepository.CreateAsync(personPerson);

                return Unit.Value;
            }

        }

    }
}
