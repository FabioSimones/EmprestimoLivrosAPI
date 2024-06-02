using EmprestimoLIvro.API.Models;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Account;
using EmprestimoLivros.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLIvro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticate, IUsuarioService usuarioService)
        {
            _authenticateService = authenticate;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste) 
            {
                return BadRequest("Esse email já está cadastrado");
            }

            else
            {
                if (User.FindFirst("id") == null)
                {
                    return Unauthorized();
                }

                var userId = User.GetId();
                var user = await _usuarioService.SelecionarAsync(userId);
                if (!user.IsAdmin)
                {
                    return Unauthorized("Você não possui permissão de incluir novos usuários.");
                }
            }

            var existeUsuarioSistema = await _usuarioService.ExisteUsuarioCadastradoAsync();
            if (!existeUsuarioSistema)
            {
                usuarioDTO.IsAdmin = true;
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);

            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }

            var token = _authenticateService.GenerateToken(usuario.ID, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe)
            {
                return Unauthorized("O Usuário não existe");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);

            if (!result)
            {
                return Unauthorized("Usuário ou senha inválido");
            }
            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);
            var token = _authenticateService.GenerateToken(usuario.ID, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
