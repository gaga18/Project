using Project.Core.Domain.Basics;
using Project.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Project.Core.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalID { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int City { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<PersonPerson> PersonPersons { get; set; }
    }
}
