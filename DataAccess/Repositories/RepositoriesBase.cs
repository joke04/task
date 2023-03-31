using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repositories
{
    public abstract class RepositoriesBase<T> : IRepositoryBase<T> where T : class
    {
        protected shop_pharmacyContext RepositoriesContext { get; set; }
        public RepositoriesBase(shop_pharmacyContext repositoriesContext)
        {
            RepositoriesContext = repositoriesContext;
        }
        public IQueryable<T> FindAll() => RepositoriesContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoriesContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoriesContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoriesContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoriesContext.Set<T>().Remove(entity);
    }
}