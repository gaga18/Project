using Project.Core.Application.Commons;
using Project.Core.Application.Interfaces.Repositories;
using Project.Core.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence.Implementations.Repositories
{
    internal class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(DataContext context) : base(context) { }

        public async Task<Pagination<PhoneNumber>> FilterAsync(int pageIndex, int pageSize, string name = null)
        {
            var PhoneNumbers = this.context.PhoneNumbers;

            return await Pagination<PhoneNumber>.CreateAsync(PhoneNumbers, pageIndex, pageSize);
        }
    }
}
