using InfoDengue.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.BancoDados.Mapeamentos;

public class ArboviroseConfiguracao : IEntityTypeConfiguration<Arbovirose>
{
    public void Configure(EntityTypeBuilder<Arbovirose> builder)
    {
        builder.ToTable(nameof(Arbovirose));

        builder.HasKey(c => c.Id);

        builder
           .Property(propriedade => propriedade.Nome)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Arbovirose.NOME_MAXIMO_CARACTERES);
    }
}