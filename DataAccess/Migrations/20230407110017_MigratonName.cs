using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id_categories = table.Column<int>(type: "int", nullable: false),
                    Category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__26BE28451999F963", x => x.Id_categories);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_number = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Namee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__A949FB8D906C53FF", x => x.User_number);
                });

            migrationBuilder.CreateTable(
                name: "filter",
                columns: table => new
                {
                    Id_categories = table.Column<int>(type: "int", nullable: false),
                    product_availability = table.Column<bool>(type: "bit", nullable: false),
                    release_form = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    availability_of_discounts = table.Column<bool>(type: "bit", nullable: false),
                    discounts = table.Column<int>(type: "int", nullable: true),
                    vacation_from_the_pharmacy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    indications = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    producer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    expiration_date = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    brand_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    quantity_in_pack = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(25,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__filter__26BE284572D39914", x => x.Id_categories);
                    table.ForeignKey(
                        name: "FK__filter__Id_categ__3E52440B",
                        column: x => x.Id_categories,
                        principalTable: "categories",
                        principalColumn: "Id_categories");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Number_product = table.Column<int>(type: "int", nullable: false),
                    Id_categories = table.Column<int>(type: "int", nullable: false),
                    Namee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Product_price = table.Column<decimal>(type: "decimal(25,2)", nullable: false),
                    Product_description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Article = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__AA6BD16A70238426", x => x.Number_product);
                    table.ForeignKey(
                        name: "FK__product__Id_cate__3B75D760",
                        column: x => x.Id_categories,
                        principalTable: "categories",
                        principalColumn: "Id_categories");
                });

            migrationBuilder.CreateTable(
                name: "saved_address",
                columns: table => new
                {
                    User_idd = table.Column<int>(type: "int", nullable: false),
                    Address_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Construction = table.Column<int>(type: "int", nullable: false),
                    Flat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__saved_ad__DF1AA3D460CBA106", x => new { x.User_idd, x.Address_name });
                    table.ForeignKey(
                        name: "FK__saved_add__User___412EB0B6",
                        column: x => x.User_idd,
                        principalTable: "users",
                        principalColumn: "User_number");
                });

            migrationBuilder.CreateTable(
                name: "basket",
                columns: table => new
                {
                    User_idd = table.Column<int>(type: "int", nullable: false),
                    Basket_number = table.Column<int>(type: "int", nullable: false),
                    Quantity_of_goods = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__basket__FEB6611CA7BADED3", x => new { x.User_idd, x.Basket_number });
                    table.ForeignKey(
                        name: "FK__basket__Basket_n__44FF419A",
                        column: x => x.Basket_number,
                        principalTable: "product",
                        principalColumn: "Number_product");
                    table.ForeignKey(
                        name: "FK__basket__User_idd__440B1D61",
                        column: x => x.User_idd,
                        principalTable: "users",
                        principalColumn: "User_number");
                });

            migrationBuilder.CreateTable(
                name: "ordering",
                columns: table => new
                {
                    Order_Number = table.Column<int>(type: "int", nullable: false),
                    User_idd = table.Column<int>(type: "int", nullable: false),
                    Number_product = table.Column<int>(type: "int", nullable: false),
                    Date_and_Time_references = table.Column<DateTime>(type: "datetime", nullable: false),
                    Statuss = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ordering__B8CE9334EB26F932", x => new { x.Order_Number, x.User_idd, x.Number_product });
                    table.ForeignKey(
                        name: "FK__ordering__Number__48CFD27E",
                        column: x => x.Number_product,
                        principalTable: "product",
                        principalColumn: "Number_product");
                    table.ForeignKey(
                        name: "FK__ordering__User_i__47DBAE45",
                        column: x => x.User_idd,
                        principalTable: "users",
                        principalColumn: "User_number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_basket_Basket_number",
                table: "basket",
                column: "Basket_number");

            migrationBuilder.CreateIndex(
                name: "IX_ordering_Number_product",
                table: "ordering",
                column: "Number_product");

            migrationBuilder.CreateIndex(
                name: "IX_ordering_User_idd",
                table: "ordering",
                column: "User_idd");

            migrationBuilder.CreateIndex(
                name: "IX_product_Id_categories",
                table: "product",
                column: "Id_categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basket");

            migrationBuilder.DropTable(
                name: "filter");

            migrationBuilder.DropTable(
                name: "ordering");

            migrationBuilder.DropTable(
                name: "saved_address");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
