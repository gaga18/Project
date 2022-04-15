using Project.Core.Application.Interfaces;
using Project.Core.Domain.Basics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<int, TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext context;
        public Repository(DataContext context) => this.context = context;


        // create
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();
        }
        // read
        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        // update
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(int id, TEntity entity)
        {
            var existing = context.Set<TEntity>().Find(id);
            this.context.Entry(existing).CurrentValues.SetValues(entity);
            return await context.SaveChangesAsync();
        }
        // delete
        public virtual async Task<int> DeleteAsync(int id)
        {
            var item = await this.ReadAsync(id);
            context.Set<TEntity>().Remove(item);
            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }
        // check
        public virtual async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().CountAsync(predicate);
        }
    }
}
