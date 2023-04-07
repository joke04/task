using Domain.Interfaces;
using Domain.Models;
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

        public async Task<List<T>> FindAll() => await RepositoriesContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            await RepositoriesContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task Create(T entity) => await RepositoriesContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => RepositoriesContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => RepositoriesContext.Set<T>().Remove(entity);
    }
}