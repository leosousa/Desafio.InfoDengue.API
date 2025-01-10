using InfoDengue.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.BancoDados.Mapeamentos;

public class RelatorioConfiguracao : IEntityTypeConfiguration<Relatorio>
{
    public void Configure(EntityTypeBuilder<Relatorio> builder)
    {
        builder.ToTable(nameof(Relatorio));

        builder.HasKey(c => c.Id);

        builder
           .Property(propriedade => propriedade.DataSolicitacao)
           .IsRequired();

        builder
           .Property(propriedade => propriedade.SemanaInicio)
           .IsRequired();

        builder
           .Property(propriedade => propriedade.SemanaTermino)
           .IsRequired();

        builder
            .Property(propriedade => propriedade.Arbovirose)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(Relatorio.ARBOVIROSE_MAXIMO_CARACTERES);

        builder
            .HasOne(propriedade => propriedade.Municipio)
            .WithMany()
            .HasForeignKey(e => e.IdMunicipio);

        builder
            .HasOne(propriedade => propriedade.Solicitante)
            .WithMany()
            .HasForeignKey(e => e.IdSolicitante);
    }
}