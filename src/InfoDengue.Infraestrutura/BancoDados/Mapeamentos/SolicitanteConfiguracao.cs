using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Infraestrutura.BancoDados.Mapeamentos;

public class SolicitanteConfiguracao : IEntityTypeConfiguration<Solicitante>
{
    public void Configure(EntityTypeBuilder<Solicitante> builder)
    {
        builder.ToTable(nameof(Solicitante));

        builder.HasKey(c => c.Id);

        builder
           .Property(propriedade => propriedade.Nome)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Solicitante.NOME_MAXIMO_CARACTERES);

        builder
           .Property(propriedade => propriedade.Cpf)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Solicitante.CPF_MAXIMO_CARACTERES);
    }
}