using AutoMapper;
using FluentValidation;
using Project.Core.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workabroad.Core.Application.Exceptions;

namespace Project.Core.Application.Features.PersonPerson.Commands
{
    public class DeletePersonPersonCommand
    {
        public class Request : IRequest
        {
            public int Id { get; private set; }

            public Request(int id) => this.Id = id;
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;

            public Handler(IUnitOfWork unit)
            {
                this.unit = unit;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var isRecord = await unit.PersonPersonRepository.CheckAsync(x => x.Id == request.Id);
                if (!isRecord)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                await unit.PersonRepository.DeleteAsync(request.Id);

                return Unit.Value;
            }
        }
    }
}
