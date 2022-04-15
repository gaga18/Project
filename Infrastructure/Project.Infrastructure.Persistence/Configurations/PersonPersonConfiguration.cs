using Project.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Persistence.Seeds;

namespace Project.Infrastructure.Persistence.Configurations
{
    internal class PersonPersonConfiguration : IEntityTypeConfiguration<PersonPerson>
    {
        public void Configure(EntityTypeBuilder<PersonPerson> builder)
        {
            builder.ToTable("PersonPersons");

            // მიგრაციის დროს წინასწარ ინფორმაცია რომ იყოს ბაზაში
            builder.HasData(PersonPersonSeed.PersonPersons);
        }
    }
}
