using EmprestimoLivroDTOs.Application.Interfaces;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLIvro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(LivroDTO livroDTO)
        {
            var livroIncluido = await _livroService.Incluir(livroDTO);
            if (livroIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o livro");
            }

            return Ok("Livro incluído com sucesso.");
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(LivroDTO livroDTO)
        {
            var livroAlterado = await _livroService.Alterar(livroDTO);
            if (livroAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o livro");
            }

            return Ok("Livro alterado com sucesso.");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            
            var livroDTOExcluido = await _livroService.Excluir(id);
            if (livroDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o livro");
            }

            return Ok("Livro excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var livroDTO = await _livroService.SelecionarAsync(id);
            if (livroDTO == null)
            {
                return NotFound("Livro não encontrado");
            }

            return Ok(livroDTO);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var livrosDTO = await _livroService.SelecionarTodosAsync();
            return Ok(livrosDTO);
        }
    }
}
