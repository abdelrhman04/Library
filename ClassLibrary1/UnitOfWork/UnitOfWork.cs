
using CORE;
using CORE.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext context;
        public UnitOfWork(MyContext _context)
        {
            context = _context;
        }

        private IRepository<Types> types;
        public IRepository<Types> Types
        {
            get { return types ?? (types = new Repository<Types>(context)); }
        }

        private IRepository<Students> students;
        public IRepository<Students> Students
        {
            get { return students ?? (students = new Repository<Students>(context)); }
        }

        private IRepository<Brorows> brorows;
        public IRepository<Brorows> Brorows
        {
            get { return brorows ?? (brorows = new Repository<Brorows>(context)); }
        }

        private IRepository<Books> books;
        public IRepository<Books> Books
        {
            get { return books ?? (books = new Repository<Books>(context)); }
        }
        private IRepository<Authors> authors;
        public IRepository<Authors> Authors
        {
            get { return authors ?? (authors = new Repository<Authors>(context)); }
        }

        private IRepository<IdentityRole> identityRole;
        public IRepository<IdentityRole> IdentityRole
        {
            get { return identityRole ?? (identityRole = new Repository<IdentityRole>(context)); }
        }


        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}
