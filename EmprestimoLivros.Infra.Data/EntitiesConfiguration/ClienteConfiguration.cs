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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.cliCPF).HasMaxLength(11).IsRequired();
            builder.Property(x => x.cliNome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.cliEndereco).HasMaxLength(50).IsRequired();
            builder.Property(x => x.cliCidade).HasMaxLength(50).IsRequired();
            builder.Property(x => x.cliBairro).HasMaxLength(50).IsRequired();
            builder.Property(x => x.cliNumero).HasMaxLength(20).IsRequired();
            builder.Property(x => x.cliTelefoneCelular).HasMaxLength(11).IsRequired();
            builder.Property(x => x.cliTelefoneFixo).HasMaxLength(10).IsRequired();
        }
    }
}
