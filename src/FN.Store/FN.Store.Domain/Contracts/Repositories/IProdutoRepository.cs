using FN.Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByNome(string name);

        Task<IEnumerable<Produto>> GetAllWithCategoriaAsync();

        Task<Produto> GetByIdWithCategoriaAsync(int id);
    }
}
