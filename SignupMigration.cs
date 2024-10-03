using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWagon.Migrations.Signup
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signup",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signup", x => x.CustomerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signup");
        }
    }
}
