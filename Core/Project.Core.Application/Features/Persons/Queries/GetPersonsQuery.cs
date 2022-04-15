using AutoMapper;
using Project.Core.Application.DTOs;
using Project.Core.Application.Interfaces;

using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Core.Application.Features.Persons.Queries
{
    public class GetPersonsQuery
    {
        public class Request : IRequest<GetPaginationDto<GetPersonDto>>
        {
            public int pageIndex { get; set; }
            public int pageSize { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PersonalId { get; set; }
        }

        public class Handler : IRequestHandler<Request, GetPaginationDto<GetPersonDto>>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }

            public async Task<GetPaginationDto<GetPersonDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var Persons = await unit.PersonRepository.FilterAsync(request.pageIndex, request.pageSize, FirstName: request.FirstName, LastName: request.LastName, PersonalId: request.PersonalId);

                return mapper.Map<GetPaginationDto<GetPersonDto>>(Persons);
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.pageIndex).GreaterThanOrEqualTo(1).WithMessage("მიუთითეთ გვერდის ნომერი");
                RuleFor(x => x.pageSize).GreaterThan(0).WithMessage("მიუთითეთ გვერდის ზომა");
            }
        }
    }
}
