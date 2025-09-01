using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Commons
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null);
        T? Get(Expression<Func<T, bool>>? expression = null);
        T Add(T entity);
        T Edit(T entity);
        void Remove(T entity);
        int Save();
    }
}
