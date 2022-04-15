using System;

namespace Project.Core.Application.DTOs
{
    public class GetPersonPersonDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }

        public int RelatedType { get; set; }

        public GetPersonDto RelatedPerson { get; set; }
    }
}
