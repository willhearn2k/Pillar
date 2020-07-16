using System;
using System.Collections.Generic;
using System.Linq;
using Pillar.Server.Models;
using Pillar.Server.DataContext.Context;
using Microsoft.EntityFrameworkCore;

namespace Pillar.Server.DataContext.Repository
{
    public abstract class PillarRepository<C, T> : 
        IPillarRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        protected C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

         public IQueryable<T> GetAll()
         {
             IQueryable<T> query = _entities.Set<T>();
             return query;
         }

         public void Create(T entity)
         {
             _entities.Add<T>(entity);
         }

         public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
         {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
         }

         public void Delete(T entity)
         {
             _entities.Remove(entity);
         }

         public bool Save()
         {
             return (_entities.SaveChanges() >= 0);
         }
    }
}