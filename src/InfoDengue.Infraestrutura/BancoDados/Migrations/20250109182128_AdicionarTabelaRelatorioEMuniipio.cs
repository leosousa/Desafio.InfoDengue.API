using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoDengue.Infraestrutura.BancoDados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaRelatorioEMuniipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbovirose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbovirose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIbge = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemanaInicio = table.Column<int>(type: "int", nullable: false),
                    SemanaTermino = table.Column<int>(type: "int", nullable: false),
                    IdArbovirose = table.Column<int>(type: "int", nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false),
                    IdSolicitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorio_Arbovirose_IdArbovirose",
                        column: x => x.IdArbovirose,
                        principalTable: "Arbovirose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorio_Municipio_IdMunicipio",
                        column: x => x.IdMunicipio,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorio_Solicitante_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdArbovirose",
                table: "Relatorio",
                column: "IdArbovirose");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdMunicipio",
                table: "Relatorio",
                column: "IdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdSolicitante",
                table: "Relatorio",
                column: "IdSolicitante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Arbovirose");

            migrationBuilder.DropTable(
                name: "Municipio");
        }
    }
}
