//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Cryptography.X509Certificates;

//namespace CORE.DAL
//{
//    public class StudentsConfiguration : IEntityTypeConfiguration<Students>
//    {
//        public void Configure(EntityTypeBuilder<Students> builder)
//        {
//            builder.ToTable("Students");
//            builder.HasKey(i => i.Id);
//            builder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
//            builder.Property(i => i.Name).IsRequired();
//            builder.Property(i => i.SurName).IsRequired();
//            builder.Property(i => i.Point ).IsRequired();
//            builder.Property(i => i.Class).IsRequired();
//            builder.Property(i => i.gender).IsRequired(); 
//            builder.Property(i => i.BirthDate).IsRequired();
//        }
//    }
//}
