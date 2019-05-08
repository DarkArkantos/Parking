using Microsoft.EntityFrameworkCore.Migrations;

namespace NewServer_V2.Migrations
{
    public partial class AWS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Places_PlaceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Floors_FloorId",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Places",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Places_PlaceId",
                table: "Cars",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Floors_FloorId",
                table: "Places",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "FloorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Places_PlaceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Floors_FloorId",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Places",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Places_PlaceId",
                table: "Cars",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Floors_FloorId",
                table: "Places",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "FloorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
