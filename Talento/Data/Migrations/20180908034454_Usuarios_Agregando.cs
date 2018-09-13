using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talento.Data.Migrations
{
    public partial class Usuarios_Agregando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<int>(maxLength: 50, nullable: false),
                    Apaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Amaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Empresa = table.Column<string>(maxLength: 255, nullable: false),
                    GiroEmpresa = table.Column<string>(maxLength: 255, nullable: false),
                    Puesto = table.Column<string>(maxLength: 255, nullable: false),
                    Telefono = table.Column<int>(maxLength: 50, nullable: false),
                    Correo = table.Column<string>(maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersViewModel");
        }
    }
}
