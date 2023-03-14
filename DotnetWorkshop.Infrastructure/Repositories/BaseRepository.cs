using DotnetWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DotnetWorkshop.Application.Interfaces.Repositories;

namespace DotnetWorkshop.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public EntityEntry<T> Entry(T entity)
        {
            return _dbContext.Entry(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            return _dbContext.AddRangeAsync(entities);
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.CountAsync();
        }

        public Task<int> CountWithQueryAsync(IQueryable<T> query)
        {
            return query.AsNoTracking().CountAsync();
        }

        public async Task<List<T>> GetAllAsync(bool track = false)
        {
            return track ? await _dbContext.Set<T>().ToListAsync()
                         : await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities.ToArray());
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }


        public Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null)
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AnyAsync();
        }
    }
}
