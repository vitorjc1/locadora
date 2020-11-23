using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_Clientes_ClienteId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_Filmes_FilmeId",
                table: "Aluguel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel");

            migrationBuilder.RenameTable(
                name: "Aluguel",
                newName: "Alugueis");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_FilmeId",
                table: "Alugueis",
                newName: "IX_Alugueis_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_ClienteId",
                table: "Alugueis",
                newName: "IX_Alugueis_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alugueis",
                table: "Alugueis",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Clientes_ClienteId",
                table: "Alugueis",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Filmes_FilmeId",
                table: "Alugueis",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "FilmeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Clientes_ClienteId",
                table: "Alugueis");

            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Filmes_FilmeId",
                table: "Alugueis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alugueis",
                table: "Alugueis");

            migrationBuilder.RenameTable(
                name: "Alugueis",
                newName: "Aluguel");

            migrationBuilder.RenameIndex(
                name: "IX_Alugueis_FilmeId",
                table: "Aluguel",
                newName: "IX_Aluguel_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Alugueis_ClienteId",
                table: "Aluguel",
                newName: "IX_Aluguel_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_Clientes_ClienteId",
                table: "Aluguel",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_Filmes_FilmeId",
                table: "Aluguel",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "FilmeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
