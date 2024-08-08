using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePharmacySystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostAuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostAuthorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostID);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    FaqID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.FaqID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    PharmacyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyWorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.PharmacyID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRoleRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_UserRoleRoleID",
                        column: x => x.UserRoleRoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketUserUserID = table.Column<int>(type: "int", nullable: false),
                    BasketDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketID);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_BasketUserUserID",
                        column: x => x.BasketUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderUserUserID = table.Column<int>(type: "int", nullable: false),
                    OrderPaymentPaymentID = table.Column<int>(type: "int", nullable: false),
                    OrderPharmacyPharmacyID = table.Column<int>(type: "int", nullable: false),
                    OrderInvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeliveryDeliveryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Deliveries_OrderDeliveryDeliveryID",
                        column: x => x.OrderDeliveryDeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_OrderPaymentPaymentID",
                        column: x => x.OrderPaymentPaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Pharmacies_OrderPharmacyPharmacyID",
                        column: x => x.OrderPharmacyPharmacyID,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_OrderUserUserID",
                        column: x => x.OrderUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionUserUserID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionFileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrescriptionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Users_PrescriptionUserUserID",
                        column: x => x.PrescriptionUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryCategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductBrandBrandID = table.Column<int>(type: "int", nullable: false),
                    ProductSupplierSupplierID = table.Column<int>(type: "int", nullable: false),
                    ProductFAQsFaqID = table.Column<int>(type: "int", nullable: false),
                    ProductImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdersOrderID = table.Column<int>(type: "int", nullable: true),
                    PharmaciesPharmacyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_ProductBrandBrandID",
                        column: x => x.ProductBrandBrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ProductCategoryCategoryID",
                        column: x => x.ProductCategoryCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_FAQs_ProductFAQsFaqID",
                        column: x => x.ProductFAQsFaqID,
                        principalTable: "FAQs",
                        principalColumn: "FaqID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Products_Pharmacies_PharmaciesPharmacyID",
                        column: x => x.PharmaciesPharmacyID,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyID");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_ProductSupplierSupplierID",
                        column: x => x.ProductSupplierSupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailOrderOrderID = table.Column<int>(type: "int", nullable: false),
                    OrderDetailProductProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "BasketID");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderDetailOrderOrderID",
                        column: x => x.OrderDetailOrderOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_OrderDetailProductProductID",
                        column: x => x.OrderDetailProductProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BasketUserUserID",
                table: "Baskets",
                column: "BasketUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BasketID",
                table: "OrderDetails",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderDetailOrderOrderID",
                table: "OrderDetails",
                column: "OrderDetailOrderOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderDetailProductProductID",
                table: "OrderDetails",
                column: "OrderDetailProductProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDeliveryDeliveryID",
                table: "Orders",
                column: "OrderDeliveryDeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPaymentPaymentID",
                table: "Orders",
                column: "OrderPaymentPaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPharmacyPharmacyID",
                table: "Orders",
                column: "OrderPharmacyPharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderUserUserID",
                table: "Orders",
                column: "OrderUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PrescriptionUserUserID",
                table: "Prescriptions",
                column: "PrescriptionUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersOrderID",
                table: "Products",
                column: "OrdersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PharmaciesPharmacyID",
                table: "Products",
                column: "PharmaciesPharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandBrandID",
                table: "Products",
                column: "ProductBrandBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryCategoryID",
                table: "Products",
                column: "ProductCategoryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFAQsFaqID",
                table: "Products",
                column: "ProductFAQsFaqID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSupplierSupplierID",
                table: "Products",
                column: "ProductSupplierSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleRoleID",
                table: "Users",
                column: "UserRoleRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
