using System.ComponentModel.DataAnnotations;

namespace EmprestimoLIvro.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
