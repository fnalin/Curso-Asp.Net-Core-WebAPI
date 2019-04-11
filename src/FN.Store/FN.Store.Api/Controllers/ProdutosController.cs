using FN.Store.Api.Models;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController: ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _produtoRepository.GetAllWithCategoriaAsync())
                .Select(p => p.ToProdutoGet());
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _produtoRepository.GetByIdWithCategoriaAsync(id);

            if (data == null) return NotFound();

            return Ok(data?.ToProdutoGet());

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProdutoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToProduto();
            _produtoRepository.Add(data);

            var produto = data.ToProdutoGet();
            produto.CategoriaNome = categoria.Nome;

            return CreatedAtRoute("GetProdutoById", new { produto.Id }, produto) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ProdutoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            var produto = await _produtoRepository.GetAsync(id);

            if (produto == null) ModelState.AddModelError("Id", "produto não localizado");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            produto.Update(model.Nome, model.Preco, model.CategoriaId);
            _produtoRepository.Update(produto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data =  await _produtoRepository.GetAsync(id);

            if (data == null)
                return BadRequest(new { Produto = new string[] { "produto não localizado" } });

            _produtoRepository.Delete(data);

            return Ok();
        }


    }
}
