using Entities.Entity;
using Repositories.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : CarSales
    {
        private readonly IGenericRepository<T> repository;

        public GenericService(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }
        public bool Add(T item)
        {
            return repository.Add(item);
        }


        public bool Any(Expression<Func<T, bool>> exp)
        {
            if (exp != null)
                return repository.Any(exp);
            else
                return false;
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return repository.GetAll(includes);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            return repository.GetAll(exp, includes);
        }

        public bool Update(T item)
        {

            if (item == null)
                return false;
            else
                return repository.Update(item);
        }
    }
}
