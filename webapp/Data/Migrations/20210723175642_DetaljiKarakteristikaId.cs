using Microsoft.EntityFrameworkCore.Migrations;

namespace rentacar.Data.Migrations
{
    public partial class DetaljiKarakteristikaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KarakteristikeDetaljaAutomobila_DetaljiKarakteristika_DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila");

            migrationBuilder.DropColumn(
                name: "KarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila");

            migrationBuilder.AlterColumn<int>(
                name: "DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KarakteristikeDetaljaAutomobila_DetaljiKarakteristika_DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila",
                column: "DetaljiKarakteristikaId",
                principalTable: "DetaljiKarakteristika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KarakteristikeDetaljaAutomobila_DetaljiKarakteristika_DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila");

            migrationBuilder.AlterColumn<int>(
                name: "DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_KarakteristikeDetaljaAutomobila_DetaljiKarakteristika_DetaljiKarakteristikaId",
                table: "KarakteristikeDetaljaAutomobila",
                column: "DetaljiKarakteristikaId",
                principalTable: "DetaljiKarakteristika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
