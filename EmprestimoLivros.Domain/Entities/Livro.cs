using EmprestimoLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Livro
    {
        public int ID { get; private set; }
        public string livroNome { get; private set; }
        public string livroAutor { get; private set; }
        public string livroEditora { get; private set; }
        public DateTime livroAnoPublicacao { get; private set; }
        public string livroEdicao { get; private set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }

        public Livro(int id, string livroNome, string livroAutor, string livroEditora,
            DateTime livroAnoPublicacao, string livroEdicao)
        {
            DomainExceptionValidation.When(id < 0, "O Id do cliente deve ser positivo.");
            ID = id;
            ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }

        public Livro(string livroNome, string livroAutor, string livroEditora, 
            DateTime livroAnoPublicacao, string livroEdicao)
        {
            ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }

        public void Update(string livroNome, string livroAutor, string livroEditora,
            DateTime livroAnoPublicacao, string livroEdicao)
        {
            ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }

        public void ValidateDomain(string livroNome, string livroAutor, string livroEditora,
            DateTime livroAnoPublicacao, string livroEdicao)
        {
            DomainExceptionValidation.When(livroNome.Length > 50, "O Nome do livro não pode ter mais que 50 caracteres.");
            DomainExceptionValidation.When(livroAutor.Length > 200, "O Autor do livro não pode ter mais que 200 caracteres.");
            DomainExceptionValidation.When(livroEditora.Length > 100, "Editor(a) com no máximo 100 caracteres.");            
            DomainExceptionValidation.When(livroEdicao.Length > 50, "A edição deve possuir no máximo 50 caracteres.");

            this.livroNome = livroNome;
            this.livroAutor = livroAutor;
            this.livroEditora = livroEditora;
            this.livroAnoPublicacao = livroAnoPublicacao;
            this.livroEdicao = livroEdicao;
        }
    }
}
