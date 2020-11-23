using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task Create(T entity) => 
            await RepositoryContext.Set<T>().AddAsync(entity);

        public async Task Delete(T entity) => await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? RepositoryContext.Set<T>().AsNoTracking()
                : RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() :
                RepositoryContext.Set<T>().Where(expression);
        }

        public async Task Update(T entity) => await Task.Run(() =>  RepositoryContext.Set<T>().Update(entity));
    }
}
