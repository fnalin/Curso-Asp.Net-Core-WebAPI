using System.Collections.Generic;

namespace FN.Store.Domain.Entities
{
    public class Categoria: Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }

    }
}
