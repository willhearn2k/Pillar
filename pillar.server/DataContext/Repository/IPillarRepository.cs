using System;
using System.Collections.Generic;
using System.Linq;
using Pillar.Server.Models;

namespace Pillar.Server.DataContext.Repository
{
    public interface IPillarRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

         void Create(T entity);

         void Delete(T entity);
         
         bool Save();
    }
}