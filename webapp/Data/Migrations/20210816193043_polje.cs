using Microsoft.EntityFrameworkCore.Migrations;

namespace rentacar.Data.Migrations
{
    public partial class polje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_AspNetUsers_KorisnikId1",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_KorisnikId1",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Wishlist");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Wishlist",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_KorisnikId",
                table: "Wishlist",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_AspNetUsers_KorisnikId",
                table: "Wishlist",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_AspNetUsers_KorisnikId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_KorisnikId",
                table: "Wishlist");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Wishlist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Wishlist",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_KorisnikId1",
                table: "Wishlist",
                column: "KorisnikId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_AspNetUsers_KorisnikId1",
                table: "Wishlist",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
