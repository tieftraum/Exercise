using Exercise.Domain.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Database.EntityConfigurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }
    }
}
