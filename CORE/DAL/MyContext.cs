using CORE.DAL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class MyContext: IdentityDbContext<Students>
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Types> Types { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Brorows> Brorows { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TypesConfiguration().Configure(modelBuilder.Entity<Types>());
            new BrorowsConfiguration().Configure(modelBuilder.Entity<Brorows>());
            new BooksConfiguration().Configure(modelBuilder.Entity<Books>());
            new AuthorsConfiguration().Configure(modelBuilder.Entity<Authors>());
            modelBuilder.MappRelationships();
            base.OnModelCreating(modelBuilder);
        }

     }
}
