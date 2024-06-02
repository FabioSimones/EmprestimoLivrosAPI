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
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            var disponivel = await _emprestimoService.VerificaDisponibilidadeAsync(emprestimoPostDTO.IdLivro);
            if (!disponivel)
            {
                return BadRequest("O livro não está disponível para empréstimo.");
            }
            emprestimoPostDTO.DataEmprestimo = DateTime.Now;
            emprestimoPostDTO.Entregue = false;
            var emprestimoIncluido = await _emprestimoService.Incluir(emprestimoPostDTO);
            if (emprestimoIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o emprestimo.");
            }

            return Ok("Emprestimo incluído com sucesso.");
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(emprestimoPutDTO.ID);
            if (emprestimoDTO == null)
            {
                return NotFound("Emprestimo não encontrado.");
            }

            emprestimoDTO.DataEntrega = emprestimoPutDTO.DataEntrega;
            emprestimoDTO.Entregue = emprestimoPutDTO.Entregue;

            var emprestimoAlterado = await _emprestimoService.Alterar(emprestimoDTO);
            if (emprestimoAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o emprestimo.");
            }

            return Ok("Emprestimo alterado com sucesso.");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {       
            var emprestimoDTOExcluido = await _emprestimoService.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o emprestimo.");
            }

            return Ok("Emprestimo excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(id);
            if (emprestimoDTO == null)
            {
                return NotFound("Emprestimo não encontrado");
            }

            return Ok(emprestimoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var emprestimosDTO = await _emprestimoService.SelecionarTodosAsync();
            return Ok(emprestimosDTO);
        }
    }
}
