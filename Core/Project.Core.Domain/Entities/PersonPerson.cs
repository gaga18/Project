using Project.Core.Domain.Basics;
using Project.Core.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Domain.Entities
{
    public class PersonPerson : AuditableEntity
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }

        public RelatedType RelatedType { get; set; }

        public virtual Person Person { get; set; }
        [NotMapped]
        public virtual Person RelatedPerson { get; set; }
    }
}
