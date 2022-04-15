using System;
using System.Collections.Generic;

namespace Project.Core.Application.DTOs
{
    public class GetPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PersonalID { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int City { get; set; }
        public string Photo { get; set; }
        public List<GetPhoneNumberDto> PhoneNumbers { get; set; }
    }
}
