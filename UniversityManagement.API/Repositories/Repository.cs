using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.API.Interfaces;

namespace UniversityManagement.API.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CoreContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CoreContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}

