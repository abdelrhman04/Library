using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public static class RelationMapping
    {
        public static void MappRelationships(this ModelBuilder builder)
        {
            builder.Entity<Brorows>().
                   HasOne(i => i.Student)
                   .WithMany(i => i.Brorows)
                   .HasForeignKey(i => i.StudentId)
                   .IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Brorows>().
                    HasOne(i => i.Book)
                    .WithMany(i => i.Brorows)
                    .HasForeignKey(i => i.Id)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Books>().
                    HasOne(i => i.Type)
                    .WithMany(i => i.Books)
                    .HasForeignKey(i => i.typeid)
                    .IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Books>().
                    HasOne(i => i.Author)
                    .WithMany(i => i.Books)
                    .HasForeignKey(i => i.authorid)
                    .IsRequired().OnDelete(DeleteBehavior.SetNull);
        }
     }   
}
