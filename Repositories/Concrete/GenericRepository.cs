using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : CarSales
    {
        private readonly CarContext context;

        public GenericRepository(CarContext context)
        {
            this.context = context;
        }
        public bool Add(T item)
        {
            try
            {

                context.Set<T>().Add(item);
                return Save() > 0; //Bir tek nesne gelip ekleme işlemi yapıldığı için Save() metodundan 1 dönüyorsa buradan true dönsün.
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Any(exp);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(exp);
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {

                context.Set<T>().Update(item);
                return Save() > 0; //Bir tek nesne gelip ekleme işlemi yapıldığı için Save() metodundan 1 dönüyorsa buradan true dönsün.
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
