using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreinoC_.Migrations
{
    /// <inheritdoc />
    public partial class PWI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_salas",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nmsala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_salas", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Tb_usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NmSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NmNick = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dsmensagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Tb_chat",
                columns: table => new
                {
                    Idchat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_chat", x => x.Idchat);
                    table.ForeignKey(
                        name: "FK_Tb_chat_Tb_salas_IdSala",
                        column: x => x.IdSala,
                        principalTable: "Tb_salas",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_chat_Tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Tb_usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_chat_IdSala",
                table: "Tb_chat",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_chat_IdUsuario",
                table: "Tb_chat",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_chat");

            migrationBuilder.DropTable(
                name: "Tb_salas");

            migrationBuilder.DropTable(
                name: "Tb_usuario");
        }
    }
}