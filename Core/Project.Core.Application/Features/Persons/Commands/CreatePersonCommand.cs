using AutoMapper;
using FluentValidation;
using MediatR;
using Project.Core.Application.DTOs;
using Project.Core.Application.Extension;
using Project.Core.Application.Interfaces;
using Project.Core.Application.Interfaces.Contracts;
using Project.Core.Domain.Entities;
using Project.Core.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Core.Application.Features.Persons.Commands
{
    public class CreatePersonCommand
    {
        public class Request : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public string PersonalID { get; set; }
            public DateTime BirthdayDate { get; set; }
            public int City { get; set; }
            public SetPhoneNumberDto[] PhoneNumbers { get; set; }
            public string Photo { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;
            private readonly IFileManager fileManager;

            public Handler(IUnitOfWork unit, IMapper mapper, IFileManager fileManager)
            {
                this.unit = unit;
                this.mapper = mapper;
                this.fileManager = fileManager;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var Person = mapper.Map<Person>(request);

                if (request.Photo != null)
                {
                    var fleName = fileManager.SaveImage(request.Photo);
                    Person.Photo = fleName;
                }

                await unit.PersonRepository.CreateAsync(Person);

                return Unit.Value;
            }

        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("სახელი სავალდებულოა")
                    .MinimumLength(2).WithMessage("სახელი უნდა შედგებოდეს მინიმუმ 2 სიმბოლოსგან")
                    .MaximumLength(50).WithMessage("სახელი უნდა შედგებოდეს მაქსიმუმ 50 სიმბოლოსგან")
                    .Matches("^([a-zA-Z]+|[ა-ჰ]+)$").WithMessage("უნდა შეიცავდეს მხოლოდ ქართული ან ლათინური ანბანის ასოებს, არ უნდა შეიცავდეს ერთდროულად ლათინურ და ქართულ ასოებს");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("გვარი სავალდებულოა")
                    .MinimumLength(2).WithMessage("გვარი უნდა შედგებოდეს მინიმუმ 2 სიმბოლოსგან")
                    .MaximumLength(50).WithMessage("გვარი უნდა შედგებოდეს მაქსიმუმ 50 სიმბოლოსგან")
                    .Matches("^([a-zA-Z]+|[ა-ჰ]+)$").WithMessage("უნდა შეიცავდეს მხოლოდ ქართული ან ლათინური ანბანის ასოებს, არ უნდა შეიცავდეს ერთდროულად ლათინურ და ქართულ ასოებს");

                RuleFor(x => x.PersonalID)
                    .NotEmpty().WithMessage("პირადი ნომერი სავალდებულოა")
                    .Length(11).WithMessage("სავალდებულო, 11 ციფრი");

                RuleFor(x => x.BirthdayDate.CalculateAge())
                    .NotEmpty().WithMessage("დაბადების თარიღი  სავალდებულოა")
                    .GreaterThanOrEqualTo(18).WithMessage("მინიმუმ 18 წლის");
            }
        }
    }
}
