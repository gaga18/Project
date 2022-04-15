using Project.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Project.Infrastructure.Persistence.Seeds;

namespace Project.Infrastructure.Persistence.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

            // ყოველ სელექთზე ფილტრი რომ დაედოს, ასევე იგნროიც შეიძლება IgnoreQueryFilters საშვალებით
            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);

            // მიგრაციის დროს წინასწარ ინფორმაცია რომ იყოს ბაზაში
            builder.HasData(PersonSeed.Persons);
        }
    }
}
