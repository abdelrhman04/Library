using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class TypesConfiguration : IEntityTypeConfiguration<Types>
    {
        public void Configure(EntityTypeBuilder<Types> builder)
        {
            builder.ToTable("Types");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired();
        }
    }
}
