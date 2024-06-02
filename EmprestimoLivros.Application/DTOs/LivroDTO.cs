using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class LivroDTO
    {
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "O nome do livro não pode passar de 50 caracteres.")]
        [Required(ErrorMessage = "O nome do livro é obrigatório.")]
        public string livroNome { get; set; }

        [MaxLength(200, ErrorMessage = "O autor do livro não pode passar de 200 caracteres.")]
        [Required(ErrorMessage = "O autor do livro é obrigatório.")]
        public string livroAutor { get; set; }

        [MaxLength(50, ErrorMessage = "A editora do livro não pode passar de 50 caracteres.")]
        [Required(ErrorMessage = "A autora do livro é obrigatório.")]
        public string livroEditora { get; set; }

        [Required(ErrorMessage = "O ano de publicação é obrigatório.")]
        public DateTime livroAnoPublicacao { get; set; }

        [MaxLength(50, ErrorMessage = "O campo de edição do livro não pode passar de 50 caracteres.")]
        [Required(ErrorMessage = "O campo de edição do livro é obrigatório.")]
        public string livroEdicao { get; set; }
    }
}
