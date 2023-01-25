

using CORE;
using CORE.DAL;
using Microsoft.AspNetCore.Identity;

namespace BLL
{
    public interface IUnitOfWork
    {

        IRepository<Types> Types { get; }
        IRepository<Students> Students { get; }
        IRepository<Brorows> Brorows { get; }
        IRepository<Books> Books { get; }
        IRepository<Authors> Authors { get; }
        IRepository<IdentityRole> IdentityRole { get; }
        void Save();
    }
}
