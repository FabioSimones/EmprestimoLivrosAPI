using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(200, ErrorMessage ="O nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O email deve ter no máximo 200 caracteres.")]
        public string Email { get; set;}

        [NotMapped]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        public string Password { get; set;}

        [JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
