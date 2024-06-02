using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivros.Infra.Data.Migrations
{
    public partial class InicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    cliNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    cliEndereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cliCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cliBairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cliNumero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cliTelefoneCelular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    cliTelefoneFixo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    livroNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    livroAutor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    livroEditora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    livroAnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    livroEdicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entregue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdCliente",
                table: "Emprestimo",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo",
                column: "IdLivro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
