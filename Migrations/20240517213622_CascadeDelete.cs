using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCalls_CustomerDatas_CustomerDataId",
                table: "CustomerCalls");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCalls_CustomerDatas_CustomerDataId",
                table: "CustomerCalls",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCalls_CustomerDatas_CustomerDataId",
                table: "CustomerCalls");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCalls_CustomerDatas_CustomerDataId",
                table: "CustomerCalls",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "Id");
        }
    }
}
