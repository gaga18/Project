using Project.Core.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.Persons.Commands
{
    public class DeletePersonCommand
    {
        public class Request : IRequest
        {
            public int PersonId { get; private set; }

            public Request(int PersonId) => this.PersonId = PersonId;
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;

            public Handler(IUnitOfWork unit) =>
                this.unit = unit;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var isRecord = await unit.PersonRepository.CheckAsync(x => x.Id == request.PersonId);
                if (!isRecord)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                await unit.PersonRepository.DeleteAsync(request.PersonId);

                return Unit.Value;
            }
        }
    }
}
