using Project.Core.Domain.Basics;
using System.Collections.Generic;

namespace Project.Core.Domain.Entities
{
    public class PhoneNumber : AuditableEntity
    {
        public int PersonId { get; set; }
        public int Type { get; set; }
        public string Number { get; set; }

        public virtual Person Persons { get; set; }
    }
}
