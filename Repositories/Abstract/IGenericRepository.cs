using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IGenericRepository<T> where T : CarSales
    {
        bool Add(T item);
        bool Update(T item);
        List<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
