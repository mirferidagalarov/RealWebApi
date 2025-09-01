using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Commons
{
    public abstract class GeneralRepository<T> : IRepository<T>
        where T : class
    {
        DbContext db { get; set; }
        DbSet<T> table { get; set; }

        public GeneralRepository(DbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }




        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            var query = table.AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            return query;
        }

        public T? Get(Expression<Func<T, bool>>? expression = null)
        {
            var query = table.AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            return query.FirstOrDefault() ?? throw new NotFoundException($"{typeof(T).Name} tapilmadi");
        }

        public T Add(T entity)
        {
            this.table.Add(entity);
            return entity;
        }

        public T Edit(T entity)
        {
            table.Update(entity);
            return entity;
        }

        public void Remove(T entity)
        {
            table.Remove(entity);
        }
        public int Save() => db.SaveChanges();
    }
}
