using Project.Core.Application.Commons;
using Project.Core.Application.Interfaces.Repositories;
using Project.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence.Implementations.Repositories
{
    internal class PersonPersonRepository : Repository<PersonPerson>, IPersonPersonRepository
    {
        public PersonPersonRepository(DataContext context) : base(context) { }

        private IQueryable<PersonPerson> Including =>
             this.context.PersonPersons.Include(x => x.Person);


        public async Task<Pagination<PersonPerson>> FilterAsync(int pageIndex, int pageSize, string FirstName, string LastName)
        {
            var PersonPersons = this.Including.Where(x =>
                (FirstName == null || x.Person.FirstName == FirstName) &&
                (LastName == null || x.Person.LastName == LastName)
            );

            return await Pagination<PersonPerson>.CreateAsync(PersonPersons, pageIndex, pageSize);
        }
    }
}
