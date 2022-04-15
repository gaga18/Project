using AutoMapper;
using Project.Core.Application.Commons;
using Project.Core.Application.DTOs;
using Project.Core.Application.Features.PersonPersons.Commands;
using Project.Core.Application.Features.Persons.Commands;
using Project.Core.Domain.Entities;
using Project.Core.Domain.Enums;

namespace Project.Core.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SetPhoneNumberDto, PhoneNumber>();
            CreateMap<PhoneNumber, SetPhoneNumberDto>();
            CreateMap<GetPhoneNumberDto, PhoneNumber>();
            CreateMap<PhoneNumber, GetPhoneNumberDto>();
            CreateMap<SetPersonDto, Person>();
            CreateMap<Person, GetPersonDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == Gender.Male ? "კაცი" : "ქალი"));
            CreateMap<CreatePersonCommand.Request, Person>();
            CreateMap<UpdatePersonCommand.Request, Person>();
            CreateMap<CreatePersonPersonCommand.Request, PersonPerson>();
            CreateMap<PersonPerson, GetPersonPersonDto>();

            CreateMap(typeof(Pagination<>), typeof(GetPaginationDto<>));
            CreateMap<Person, GetFullPersonDto>();

        }
    }
}
