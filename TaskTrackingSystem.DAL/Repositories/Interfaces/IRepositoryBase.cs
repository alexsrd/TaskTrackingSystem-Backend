using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface for base repository with main functionality
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<List<TEntity>> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match);
        
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        Task<TEntity> InsertAsync(TEntity entity);
        

        void Delete(TEntity entity);
        
    }
}