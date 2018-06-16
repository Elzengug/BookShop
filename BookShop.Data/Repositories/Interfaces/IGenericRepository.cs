using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Core.Models.Base;

namespace BookShop.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetItemsAsync();
        Task<ICollection<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task<bool> RemoveAsync(TEntity item);
    }

    public interface IGenericRepository<TEntity, in TKey> : IGenericRepository<TEntity>
        where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetItemAsync(TKey itemId);
        Task<bool> RemoveAsync(TKey itemId);
    }
}
