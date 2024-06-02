using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoPutDTO
    {
        [Required(ErrorMessage = "O identificador de emprestimo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do empréstimo é inválido.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "A data da entrega é obrigatório.")]
        public DateTime DataEntrega { get; set; }

        [Required(ErrorMessage = "O estado da entrega é obrigatório.")]
        public bool Entregue { get; set; }
    }
}
