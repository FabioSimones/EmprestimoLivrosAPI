using EmprestimoLIvro.API.Extensions;
using EmprestimoLIvro.API.Models;
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
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IUsuarioService _usuarioService;

        public ClienteController(IClienteService clienteService, IUsuarioService usuarioService)
        {
            _clienteService = clienteService;
            _usuarioService = usuarioService;
        }

        [HttpPost]        
        public async Task<IActionResult> Incluir(ClienteDTO clienteDTO)
        {
            var clienteIncluido = await _clienteService.Incluir(clienteDTO);
            if (clienteIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o cliente");
            }

            return Ok("Cliente incluído com sucesso.");
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(ClienteDTO clienteDTO)
        {
            var clienteAlterado = await _clienteService.Alterar(clienteDTO);
            if (clienteAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente");
            }

            return Ok("Cliente alterado com sucesso.");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var userId = User.GetId(); 
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (usuario.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir o cliente.");
            }

            var clienteDTOExcluido = await _clienteService.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente");
            }

            return Ok("Cliente excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var clienteDTO = await _clienteService.SelecionarAsync(id);
            if (clienteDTO == null)
            {
                return NotFound("Cliente não encontrado");
            }

            return Ok(clienteDTO);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos([FromQuery]PaginationParameters paginationParameters)
        {
            var clientesDTO = await _clienteService.SelecionarTodosAsync
                (paginationParameters.PageNumber, paginationParameters.PageSize);

            Response.AddPaginationHeader(new PaginationHeader
                (clientesDTO.CurrentPage, clientesDTO.PagedSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

            return Ok(clientesDTO);
        }
    }
}
