using FN.Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(object id);

    }
}
