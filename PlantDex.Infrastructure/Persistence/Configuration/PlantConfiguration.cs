using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Infrastructure.Persistence.Configuration
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x._Id);
        }
    }
}
