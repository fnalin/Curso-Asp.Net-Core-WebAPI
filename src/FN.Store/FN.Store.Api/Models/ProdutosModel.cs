using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Api.Models
{
    public class ProdutosGet
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }

    }

    public class ProdutoAddEdit
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite de caracteres excedido")]
        public string Nome { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "valor inválido")]
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }


    public static class ProdutosModelExtension
    {
        public static ProdutosGet ToProdutoGet(this Produto entity)
        {
            return
                new ProdutosGet
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Preco = entity.Preco,
                    CategoriaId = entity.CategoriaId,
                    CategoriaNome = entity.Categoria?.Nome
                };
        }

        public static Produto ToProduto(this ProdutoAddEdit model)
        {
            return new Produto
            {
                Nome = model.Nome,
                Preco = model.Preco,
                CategoriaId = model.CategoriaId
            };
        }

    }



}
