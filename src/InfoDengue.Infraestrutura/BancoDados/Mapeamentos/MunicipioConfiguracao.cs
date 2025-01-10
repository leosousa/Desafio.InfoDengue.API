using InfoDengue.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoDengue.Infraestrutura.BancoDados.Mapeamentos;

public class MunicipioConfiguracao : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable(nameof(Municipio));

        builder.HasKey(c => c.Id);

        builder
           .Property(propriedade => propriedade.CodigoIbge)
           .IsRequired();

        builder
           .Property(propriedade => propriedade.Nome)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(Municipio.NOME_MAXIMO_CARACTERES);
    }
}