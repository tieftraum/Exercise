using Exercise.Domain.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise.Database.EntityConfigurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(32).IsRequired();
            builder.Property(x => x.ModelName).HasMaxLength(64).IsRequired();
            builder.Property(x => x.Price).HasColumnType("money").IsRequired();

            builder.HasOne(p => p.Manufacturer)
                   .WithMany(m => m.Phones)
                   .HasForeignKey(p => p.ManufacturerId);
        }
    }
}
