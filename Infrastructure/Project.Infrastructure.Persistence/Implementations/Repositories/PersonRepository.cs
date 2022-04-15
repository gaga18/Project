using Project.Core.Application.Commons;
using Project.Core.Application.Interfaces.Repositories;
using Project.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence.Implementations.Repositories
{
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context) { }

        private IQueryable<Person> Including =>
            this.context.Persons.Include(x => x.PhoneNumbers).Include(x => x.PersonPersons);

        public override async Task<Person> ReadAsync(int id)
        {
            return await this.Including.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pagination<Person>> FilterAsync(int pageIndex, int pageSize, string firstName = null, string lastName = null, string personalId = null)
        {
            var Persons = this.Including.Where(x =>
                (firstName == null || x.FirstName == firstName) &&
                (lastName == null || x.LastName == lastName) &&
                (personalId == null || x.PersonalID == personalId)
            );

            return await Pagination<Person>.CreateAsync(Persons, pageIndex, pageSize);
        }

        public async Task<Pagination<Person>> SearchAsync(int pageIndex, int pageSize, string text)
        {
            var Persons = this.context.Persons.Where(x => x.FirstName == text || x.LastName == text);

            return await Pagination<Person>.CreateAsync(Persons, pageIndex, pageSize);
        }
    }
}
