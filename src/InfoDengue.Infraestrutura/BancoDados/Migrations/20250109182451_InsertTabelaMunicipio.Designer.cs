﻿// <auto-generated />
using System;
using InfoDengue.Infraestrutura.BancoDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfoDengue.Infraestrutura.BancoDados.Migrations
{
    [DbContext(typeof(InfoDengueDbContext))]
    [Migration("20250109182451_InsertTabelaMunicipio")]
    partial class InsertTabelaMunicipio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InfoDengue.Dominio.Entidades.Arbovirose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Arbovirose", (string)null);
                });

            modelBuilder.Entity("InfoDengue.Dominio.Entidades.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoIbge")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Municipio", (string)null);
                });

            modelBuilder.Entity("InfoDengue.Dominio.Entidades.Relatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArbovirose")
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("IdSolicitante")
                        .HasColumnType("int");

                    b.Property<int>("SemanaInicio")
                        .HasColumnType("int");

                    b.Property<int>("SemanaTermino")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdArbovirose");

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdSolicitante");

                    b.ToTable("Relatorio", (string)null);
                });

            modelBuilder.Entity("InfoDengue.Dominio.Entidades.Solicitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Solicitante", (string)null);
                });

            modelBuilder.Entity("InfoDengue.Dominio.Entidades.Relatorio", b =>
                {
                    b.HasOne("InfoDengue.Dominio.Entidades.Arbovirose", "Arbovirose")
                        .WithMany()
                        .HasForeignKey("IdArbovirose")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfoDengue.Dominio.Entidades.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfoDengue.Dominio.Entidades.Solicitante", "Solicitante")
                        .WithMany()
                        .HasForeignKey("IdSolicitante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arbovirose");

                    b.Navigation("Municipio");

                    b.Navigation("Solicitante");
                });
#pragma warning restore 612, 618
        }
    }
}
