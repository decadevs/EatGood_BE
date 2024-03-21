using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data.Repositories.Generic.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> Query();
        Task AddRangeAsync(List<TEntity> entities);
    }
}
