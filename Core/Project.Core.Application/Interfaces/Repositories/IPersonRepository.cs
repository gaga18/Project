using Project.Core.Application.Commons;
using Project.Core.Domain.Entities;

using System;
using System.Threading.Tasks;

namespace Project.Core.Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        Task<Pagination<Person>> FilterAsync(int pageIndex, int pageSize, string FirstName = null, string LastName = null, string PersonalId = null);
        Task<Pagination<Person>> SearchAsync(int pageIndex, int pageSize, string text);
    }
}
