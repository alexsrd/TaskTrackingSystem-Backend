using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.EF;
using TaskTrackingSystem.DAL.Repositories.Interfaces;

namespace TaskTrackingSystem.DAL.Repositories
{
    /// <summary>
    /// Basic repository with all main functionality implemented
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public async Task<List<TEntity>> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        
        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                _context.ChangeTracker.AutoDetectChangesEnabled = false;
                await _context.SaveChangesAsync();
                return entityToUpdate;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        
    }
}