using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Liduina.Backend.Data.Entities;
using Liduina.Backend.Data.Providers;
using Microsoft.EntityFrameworkCore;

namespace Liduina.Backend.Data.Repositories
{
    public class GenericRepository<TEntity>
        where TEntity : Base
    {
        private readonly LiduinaContext _context;

        public GenericRepository(LiduinaContext context)
        {
            _context = context;
        }
        
        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(long id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null)
                return false;

            TEntity existing = await Get(entity.Id);
            if (existing != null)
            {
                existing.UpdateProperties(entity);
                await _context.SaveChangesAsync();
            }
            return existing != null;
        }
        
        public async Task<bool> Delete(TEntity entity)
        {
            entity.DeletedOn = DateTime.Now;
            return await Update(entity);
        }

        public async Task<int> Count()
        {
            return await _context.Set<TEntity>().CountAsync();
        }
    }
}
