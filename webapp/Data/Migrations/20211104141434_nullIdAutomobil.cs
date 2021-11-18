using Microsoft.EntityFrameworkCore.Migrations;

namespace rentacar.Data.Migrations
{
    public partial class nullIdAutomobil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ugovor_Automobil_AutomobilId",
                table: "Ugovor");

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Ugovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ugovor_Automobil_AutomobilId",
                table: "Ugovor",
                column: "AutomobilId",
                principalTable: "Automobil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ugovor_Automobil_AutomobilId",
                table: "Ugovor");

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Ugovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ugovor_Automobil_AutomobilId",
                table: "Ugovor",
                column: "AutomobilId",
                principalTable: "Automobil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
