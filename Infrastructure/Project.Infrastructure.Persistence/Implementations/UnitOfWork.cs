using Project.Core.Application.Interfaces;
using Project.Core.Application.Interfaces.Repositories;
using Project.Infrastructure.Persistence.Implementations.Repositories;

namespace Project.Infrastructure.Persistence.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IPhoneNumberRepository phoneNumberRepository;
        private IPersonRepository personRepository;
        private IPersonPersonRepository personPersonRepository;

        private readonly DataContext context;
        public UnitOfWork(DataContext context) => this.context = context;


        public IPhoneNumberRepository PhoneNumberRepository => phoneNumberRepository ??= new PhoneNumberRepository(context);
        public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);
        public IPersonPersonRepository PersonPersonRepository => personPersonRepository ??= new PersonPersonRepository(context);
    }
}
