using Microsoft.EntityFrameworkCore.Migrations;

namespace NewServer_V2.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Cars_CurrentCarId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CurrentCarId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CurrentCarId",
                table: "Places");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCarId",
                table: "Places",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_CurrentCarId",
                table: "Places",
                column: "CurrentCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Cars_CurrentCarId",
                table: "Places",
                column: "CurrentCarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
