using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync();
        Task<bool> ExisteUsuarioCadastradoAsync();
    }
}
