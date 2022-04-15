using Project.Core.Domain.Entities;
using Project.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Project.Infrastructure.Persistence.Seeds
{
    internal static class PersonPersonSeed
    {
        internal static readonly PersonPerson[] PersonPersons = new PersonPerson[]
        {
                new PersonPerson { Id = 1, RelatedType = RelatedType.Relative, PersonId = 1, RelatedPersonId = 2},
                new PersonPerson { Id = 2, RelatedType = RelatedType.Relative, PersonId = 1, RelatedPersonId = 3},
                new PersonPerson { Id = 3, RelatedType = RelatedType.Colleague, PersonId = 1, RelatedPersonId = 4},
                new PersonPerson { Id = 4, RelatedType = RelatedType.Colleague, PersonId = 1, RelatedPersonId = 5},

                new PersonPerson { Id = 5, RelatedType = RelatedType.Relative, PersonId = 6, RelatedPersonId = 7},
                new PersonPerson { Id = 6, RelatedType = RelatedType.Relative, PersonId = 6, RelatedPersonId = 8},
                new PersonPerson { Id = 7, RelatedType = RelatedType.Colleague, PersonId = 6, RelatedPersonId = 9},
                new PersonPerson { Id = 8, RelatedType = RelatedType.Other, PersonId = 6, RelatedPersonId = 10},
        };
    }
}
