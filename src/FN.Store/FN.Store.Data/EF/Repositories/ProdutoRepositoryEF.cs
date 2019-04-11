using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoriaAsync()
        {
            return await 
                        _db 
                            .Include(p => p.Categoria)
                        .ToListAsync();
        }

        public async Task<Produto> GetByIdWithCategoriaAsync(int id)
        {
            return await
                        _db
                            .Include(p => p.Categoria)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetByNome(string name)
        {
            return await _db.Where(p => p.Nome.Contains(name)).ToListAsync();
        }
    }
}
