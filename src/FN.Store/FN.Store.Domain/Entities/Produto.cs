namespace FN.Store.Domain.Entities
{
    public class Produto: Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
