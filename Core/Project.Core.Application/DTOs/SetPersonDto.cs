using Project.Core.Domain.Enums;
using System;

namespace Project.Core.Application.DTOs
{
    public class SetPersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalID { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int City { get; set; }
        public string Photo { get; set; }
    }
}
