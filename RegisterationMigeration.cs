using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWagon.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registeration",
                columns: table => new
                {
                    EmailID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RestaurantAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registeration", x => x.EmailID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registeration");
        }
    }
}
