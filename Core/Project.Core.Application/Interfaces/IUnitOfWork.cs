using Project.Core.Application.Interfaces.Repositories;

namespace Project.Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IPhoneNumberRepository PhoneNumberRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPersonPersonRepository PersonPersonRepository { get; }
    }
}
