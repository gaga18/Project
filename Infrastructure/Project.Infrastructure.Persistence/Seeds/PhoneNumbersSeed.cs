using Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence.Seeds
{
    internal static class PhoneNumbersSeed
    {
        internal static readonly PhoneNumber[] PhoneNumbers = new PhoneNumber[]
        {
                new PhoneNumber { Id = 1, PersonId = 1, Type = 1, Number = "598557711"},
                new PhoneNumber { Id = 2, PersonId = 1, Type = 1, Number = "598557712"},

                new PhoneNumber { Id = 3, PersonId = 2, Type = 1, Number = "598557713"},
                new PhoneNumber { Id = 4, PersonId = 2, Type = 1, Number = "598557714"},
                new PhoneNumber { Id = 5, PersonId = 3, Type = 1, Number = "598557715"},
                new PhoneNumber { Id = 6, PersonId = 3, Type = 1, Number = "598557716"},
                new PhoneNumber { Id = 7, PersonId = 6, Type = 1, Number = "598557717"},
                new PhoneNumber { Id = 8, PersonId = 7, Type = 1, Number = "598557718"},
                new PhoneNumber { Id = 9, PersonId = 8, Type = 1, Number = "598557719"},
        };
    }
}
