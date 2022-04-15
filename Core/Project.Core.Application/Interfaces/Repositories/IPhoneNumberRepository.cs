using Project.Core.Application.Commons;
using Project.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Project.Core.Application.Interfaces.Repositories
{
    public interface IPhoneNumberRepository : IRepository<int, PhoneNumber>
    {
        Task<Pagination<PhoneNumber>> FilterAsync(int pageIndex, int pageSize, string Name = null);
    }
}
