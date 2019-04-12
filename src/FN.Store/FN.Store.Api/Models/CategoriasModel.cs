using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Api.Models
{
    public class CategoriasGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaAddEdit
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "limite de caracteres excedido")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "limite de caracteres excedido")]
        public string Descricao { get; set; }
    }

    public static class CategoriasModelExtensions
    {

        public static CategoriasGet ToCategoriaGet(this Categoria data) =>
            new CategoriasGet
            {
                Id = data.Id,
                Nome = data.Nome,
                Descricao = data.Descricao
            };

        public static Categoria ToCategoria(this CategoriaAddEdit model) =>
            new Categoria
            {
                Nome = model.Nome,
                Descricao = model.Descricao
            };


    }
}
