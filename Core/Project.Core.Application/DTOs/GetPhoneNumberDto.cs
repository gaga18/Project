using System;

namespace Project.Core.Application.DTOs
{
    public class GetPhoneNumberDto
    {
        public int PersonId { get; set; }
        public int Type { get; set; }
        public string Number { get; set; }
    }
}
