using Microsoft.EntityFrameworkCore.Migrations;

namespace KeepItDRY.DAL.Migrations
{
    public partial class AddressOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Owners_OwnerId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Owners_OwnerId",
                table: "Addresses",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Owners_OwnerId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Owners_OwnerId",
                table: "Addresses",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
