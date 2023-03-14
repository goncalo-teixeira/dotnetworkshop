using DotnetWorkshop.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        EntityEntry<T> Entry(T entity);

        Task<List<T>> GetAllAsync(bool track = false);

        Task<T> AddAsync(T entity);

        T Add(T entity);

        void AddRange(IEnumerable<T> entities);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entity);

        Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null);

        Task DeleteAsync(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);

        Task<int> CountWithQueryAsync(IQueryable<T> query);

        void Delete(T entity);
    }
}
