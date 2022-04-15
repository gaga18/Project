using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain.Entities;
using Project.Infrastructure.Persistence.Seeds;

namespace Project.Infrastructure.Persistence.Configurations
{
    internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers");
            builder.Property(x => x.Number).HasMaxLength(50).IsRequired();

            // მიგრაციის დროს წინასწარ ინფორმაცია რომ იყოს ბაზაში
            builder.HasData(PhoneNumbersSeed.PhoneNumbers);
        }
    }
}
