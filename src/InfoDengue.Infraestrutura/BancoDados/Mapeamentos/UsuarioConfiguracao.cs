using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Infraestrutura.BancoDados.Mapeamentos;

public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(c => c.Id);

        builder
           .Property(propriedade => propriedade.Nome)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Usuario.NOME_MAXIMO_CARACTERES);

        builder
           .Property(propriedade => propriedade.Cpf)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Usuario.CPF_MAXIMO_CARACTERES);
    }
}