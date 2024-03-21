using Eat_Good_Data.Repositories.Generic.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data.Repositories.Generic.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EatGood_DBContext _db;

        public Repository(EatGood_DBContext db)
        {
            _db = db;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return _db.Set<TEntity>().AsQueryable();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
