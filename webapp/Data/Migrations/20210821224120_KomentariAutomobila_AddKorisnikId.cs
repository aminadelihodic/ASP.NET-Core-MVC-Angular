using Microsoft.EntityFrameworkCore.Migrations;

namespace rentacar.Data.Migrations
{
    public partial class KomentariAutomobila_AddKorisnikId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnikId",
                table: "KomentariAutomobila",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KomentariAutomobila_KorisnikId",
                table: "KomentariAutomobila",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_KomentariAutomobila_AspNetUsers_KorisnikId",
                table: "KomentariAutomobila",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KomentariAutomobila_AspNetUsers_KorisnikId",
                table: "KomentariAutomobila");

            migrationBuilder.DropIndex(
                name: "IX_KomentariAutomobila_KorisnikId",
                table: "KomentariAutomobila");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "KomentariAutomobila");
        }
    }
}
