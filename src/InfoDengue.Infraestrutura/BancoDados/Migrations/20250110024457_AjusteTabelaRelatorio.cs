using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoDengue.Infraestrutura.BancoDados.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatorio_Arbovirose_IdArbovirose",
                table: "Relatorio");

            migrationBuilder.DropTable(
                name: "Arbovirose");

            migrationBuilder.DropIndex(
                name: "IX_Relatorio_IdArbovirose",
                table: "Relatorio");

            migrationBuilder.DropColumn(
                name: "IdArbovirose",
                table: "Relatorio");

            migrationBuilder.AddColumn<string>(
                name: "Arbovirose",
                table: "Relatorio",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arbovirose",
                table: "Relatorio");

            migrationBuilder.AddColumn<int>(
                name: "IdArbovirose",
                table: "Relatorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdArbovirose",
                table: "Relatorio",
                column: "IdArbovirose");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorio_Arbovirose_IdArbovirose",
                table: "Relatorio",
                column: "IdArbovirose",
                principalTable: "Arbovirose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
