using System.ComponentModel.DataAnnotations;

namespace EmprestimoLIvro.API.Models
{
    public class PaginationParameters
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(1, 50, ErrorMessage = "O máximo de itens por paginas é 50.")]
        public int PageSize { get; set; }
    }
}
