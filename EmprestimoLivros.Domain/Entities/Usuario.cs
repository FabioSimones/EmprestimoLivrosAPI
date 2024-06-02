using EmprestimoLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Usuario
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }


        public Usuario(int id, string nome, string email) 
        {
            DomainExceptionValidation.When(id < 0, "O ID não pode ser negativo.");
            ID = id;
            ValidateDomain(nome, email);
            
        }

        public Usuario(string nome, string email)
        {            
            ValidateDomain(nome, email);
        }

        public void SetAdmin(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(nome.Length > 200, "O Nome não pode ter mais de 200 caracteres.");
            DomainExceptionValidation.When(nome == null, "O Nome não pode ficar nulo.");
            DomainExceptionValidation.When(email.Length > 200, "O Email não pode ter mais de 200 caracteres.");
            DomainExceptionValidation.When(email == null, "O Email não pode ser nulo.");
            Nome = nome;
            Email = email;
            IsAdmin = false;
        }
    }
}
