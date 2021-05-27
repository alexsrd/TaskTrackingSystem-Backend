using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTrackingSystem.DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
        Task<TEntity> InsertAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}