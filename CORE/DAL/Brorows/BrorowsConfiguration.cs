using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class BrorowsConfiguration : IEntityTypeConfiguration<Brorows>
    {
        public void Configure(EntityTypeBuilder<Brorows> builder)
        {
            builder.ToTable("Brorows");
            builder.HasKey(x => new {
                x.Id,
                x.StudentId
            });
            builder.Property(i => i.Id).HasColumnName("BookId").IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.TakenDate).IsRequired();
            builder.Property(i => i.BroughDate).IsRequired();
            builder.Property(i => i.StudentId).IsRequired();
        }
    }
}
