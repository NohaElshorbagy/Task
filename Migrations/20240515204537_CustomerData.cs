using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class CustomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "اسم",
                table: "CustomerDatas");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client_source",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer_rating",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jop",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mobile",
                table: "CustomerDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber1",
                table: "CustomerDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber2",
                table: "CustomerDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Salesman",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Whatsapp_Number",
                table: "CustomerDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "residence",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Client_source",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Customer_rating",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "District",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Jop",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "PhoneNumber1",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Salesman",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Whatsapp_Number",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "residence",
                table: "CustomerDatas");

            migrationBuilder.AddColumn<string>(
                name: "اسم",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
