using FullstackAfiliados.Domain.Entities.Base;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Domain.Services.Implemented
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;

        public BaseService(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            // Retrieve an entity by ID
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            // Create an entity
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            // Mark the entity as deleted
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                return null; // Entity not found
            }

            existingEntity.Update(entity); // Update entity properties
            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            // Check if an entity with the given ID exists
            return await _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}