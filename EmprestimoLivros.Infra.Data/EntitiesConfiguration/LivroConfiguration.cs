using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.EntitiesConfiguration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.livroNome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.livroAutor).HasMaxLength(200).IsRequired();
            builder.Property(x => x.livroEditora).HasMaxLength(100).IsRequired();
            builder.Property(x => x.livroAnoPublicacao).IsRequired();
            builder.Property(x => x.livroEdicao).HasMaxLength(50).IsRequired();
        }
    }
}
