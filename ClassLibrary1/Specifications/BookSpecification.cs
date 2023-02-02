using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class BookSpecification<T> : BaseSpecification<T> where T : Books
    {
        public BookSpecification() : base()
        {

        }
        public BookSpecification(int id) : base(x => x.Id == id)
        {

        }
        public BookSpecification(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, params Expression<Func<T, object>>[] includes) : base(filter)
        {
            foreach (Expression<Func<T, object>> include in includes)
                AddInclude(include);
            if (orderBy != null)
                AddOrderBy(orderBy);
        }
    }
}
