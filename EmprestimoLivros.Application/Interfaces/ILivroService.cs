using EmprestimoLivros.Application.DTOs;

namespace EmprestimoLivroDTOs.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroDTO> Incluir(LivroDTO livroDTO);
        Task<LivroDTO> Alterar(LivroDTO livroDTO);
        Task<LivroDTO> Excluir(int id);
        Task<LivroDTO> SelecionarAsync(int id);
        Task<IEnumerable<LivroDTO>> SelecionarTodosAsync();
    }
}
