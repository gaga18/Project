using Project.Core.Application.Commons;
using Project.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Project.Core.Application.Interfaces.Repositories
{
    public interface IPersonPersonRepository : IRepository<int, PersonPerson>
    {
        Task<Pagination<PersonPerson>> FilterAsync(int pageIndex, int pageSize, string PersonName, string Name);
    }
}
