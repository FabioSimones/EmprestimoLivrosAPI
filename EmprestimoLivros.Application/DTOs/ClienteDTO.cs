using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class ClienteDTO
    {
        [IgnoreDataMember]
        public int ID { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter no mínimo 11 caracteres.")]
        public string cliCPF { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter no máximo 200 caracteres.")]
        public string cliNome { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O Endereço deve ter no máximo 50 caracteres.")]
        public string cliEndereco { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres.")]
        public string cliCidade { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O Bairro deve ter no máximo 50 caracteres.")]
        public string cliBairro { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O Número deve ter no máximo 20 caracteres.")]
        public string cliNumero { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O Celular deve ter no máximo 11 caracteres.")]
        public string cliTelefoneCelular { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "O Telefone deve ter no máximo 10 caracteres.")]
        public string cliTelefoneFixo { get; set; }
    }
}
