using Microsoft.EntityFrameworkCore.Migrations;

namespace rentacar.Data.Migrations
{
    public partial class Proizvodjac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProizvodjacID",
                table: "Automobil",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobil_ProizvodjacID",
                table: "Automobil",
                column: "ProizvodjacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobil_Proizvodjac_ProizvodjacID",
                table: "Automobil",
                column: "ProizvodjacID",
                principalTable: "Proizvodjac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobil_Proizvodjac_ProizvodjacID",
                table: "Automobil");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropIndex(
                name: "IX_Automobil_ProizvodjacID",
                table: "Automobil");

            migrationBuilder.DropColumn(
                name: "ProizvodjacID",
                table: "Automobil");

        }
    }
}
