using EmprestimoLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Cliente
    {
        public int ID { get; private set; }
        public string cliCPF { get; private set; }
        public string cliNome { get; private set; }
        public string cliEndereco { get; private set; }
        public string cliCidade { get; private set; }
        public string cliBairro { get; private set; }
        public string cliNumero { get; private set; }
        public string cliTelefoneCelular { get; private set; }
        public string cliTelefoneFixo { get; private set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }

        public Cliente(int id, string cliCPF, string cliNome, string cliEndereco, string cliCidade,
            string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            DomainExceptionValidation.When(id < 0, "O Id do cliente deve ser positivo.");
            ID = id;
            ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }

        public Cliente(string cliCPF, string cliNome, string cliEndereco, string cliCidade, 
            string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro, 
                cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }

        public void Update(string cliCPF, string cliNome, string cliEndereco, string cliCidade,
            string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro,
                cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }

        public void ValidateDomain(string cliCPF, string cliNome, string cliEndereco, string cliCidade,
            string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {

            DomainExceptionValidation.When(cliCPF.Length != 11, "O CPF deve ter 11 caracteres.");
            DomainExceptionValidation.When(cliNome.Length > 200, "O Nome deve ter no máximo 200 caracteres.");
            DomainExceptionValidation.When(cliEndereco.Length > 50, "O Endereço dever ter no máximo 50 caracteres.");
            DomainExceptionValidation.When(cliCidade.Length > 50, "A Cidade dever ter no máximo 50 caracteres.");
            DomainExceptionValidation.When(cliBairro.Length > 50, "O Bairro dever ter no máximo 50 caracteres.");
            DomainExceptionValidation.When(cliNumero.Length > 20, "O Número dever ter no máximo 20 caracteres.");
            DomainExceptionValidation.When(cliTelefoneCelular.Length > 11, "O Celular dever ter no máximo 11 caracteres.");
            DomainExceptionValidation.When(cliTelefoneFixo.Length > 10, "O Telefone dever ter no máximo 50 caracteres.");

            this.cliCPF = cliCPF;
            this.cliNome = cliNome;
            this.cliEndereco = cliEndereco;
            this.cliCidade = cliCidade;
            this.cliBairro = cliBairro;
            this.cliNumero = cliNumero;
            this.cliTelefoneCelular = cliTelefoneCelular;
            this.cliTelefoneFixo = cliTelefoneFixo;
        }
    }
}
