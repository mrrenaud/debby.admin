using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Model;
using System;

namespace Debby.Admin.Sample.Migrations
{
    public partial class NorthwindModel : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Customer",
                c => new
                {
                    CustomerID = c.String(),
                    Address = c.String(),
                    City = c.String(),
                    CompanyName = c.String(),
                    ContactName = c.String(),
                    ContactTitle = c.String(),
                    Country = c.String(),
                    Fax = c.String(),
                    Phone = c.String(),
                    PostalCode = c.String(),
                    Region = c.String()
                })
                .PrimaryKey("PK_Customer", t => t.CustomerID);

            migrationBuilder.CreateTable("Employee",
                c => new
                {
                    EmployeeID = c.Int(nullable: false, identity: true),
                    Address = c.String(),
                    BirthDate = c.DateTime(nullable: true),
                    City = c.String(),
                    Country = c.String(),
                    Extension = c.String(),
                    FirstName = c.String(),
                    HireDate = c.DateTime(nullable: true),
                    HomePhone = c.String(),
                    LastName = c.String(),
                    Notes = c.String(),
                    Photo = c.Binary(),
                    PhotoPath = c.String(),
                    PostalCode = c.String(),
                    Region = c.String(),
                    Title = c.String(),
                    TitleOfCourtesy = c.String()
                })
                .PrimaryKey("PK_Employee", t => t.EmployeeID);

            migrationBuilder.CreateTable("EmployeeTerritory",
                c => new
                {
                    EmployeeTerritoryID = c.Int(nullable: false, identity: true),
                    EmployeeID = c.Int(nullable: false)
                })
                .PrimaryKey("PK_EmployeeTerritory", t => t.EmployeeTerritoryID);

            migrationBuilder.CreateTable("Order",
                c => new
                {
                    OrderID = c.Int(nullable: false, identity: true),
                    Freight = c.Short(nullable: true),
                    OrderDate = c.DateTime(nullable: true),
                    RequiredDate = c.DateTime(nullable: true),
                    ShipAddress = c.String(),
                    ShipCity = c.String(),
                    ShipCountry = c.String(),
                    ShipName = c.String(),
                    ShippedDate = c.DateTime(nullable: true),
                    ShipPostalCode = c.String(),
                    ShipRegion = c.String()
                })
                .PrimaryKey("PK_Order", t => t.OrderID);

            migrationBuilder.CreateTable("OrderDetail",
                c => new
                {
                    OrderDetailId = c.Int(nullable: false, identity: true),
                    Discount = c.Single(nullable: false),
                    OrderID = c.Int(nullable: false),
                    ProductID = c.Int(nullable: false),
                    Quantity = c.Decimal(nullable: false),
                    UnitPrice = c.Decimal(nullable: false)
                })
                .PrimaryKey("PK_OrderDetail", t => t.OrderDetailId);

            migrationBuilder.CreateTable("Product",
                c => new
                {
                    ProductID = c.Int(nullable: false, identity: true),
                    Discontinued = c.Boolean(nullable: false),
                    ProductName = c.String(),
                    QuantityPerUnit = c.String(),
                    ReorderLevel = c.Short(nullable: true),
                    SupplierID = c.Int(nullable: false),
                    UnitPrice = c.Decimal(nullable: false),
                    UnitsInStock = c.Short(nullable: true),
                    UnitsOnOrder = c.Short(nullable: true)
                })
                .PrimaryKey("PK_Product", t => t.ProductID);

            migrationBuilder.CreateTable("Region",
                c => new
                {
                    RegionID = c.Int(nullable: false, identity: true),
                    RegionDescription = c.String()
                })
                .PrimaryKey("PK_Region", t => t.RegionID);

            migrationBuilder.CreateTable("Shipper",
                c => new
                {
                    ShipperID = c.Int(nullable: false, identity: true),
                    CompanyName = c.String(),
                    Phone = c.String()
                })
                .PrimaryKey("PK_Shipper", t => t.ShipperID);

            migrationBuilder.CreateTable("Supplier",
                c => new
                {
                    SupplierID = c.Int(nullable: false, identity: true),
                    Address = c.String(),
                    City = c.String(),
                    CompanyName = c.String(),
                    ContactName = c.String(),
                    ContactTitle = c.String(),
                    Country = c.String(),
                    Fax = c.String(),
                    HomePage = c.String(),
                    Phone = c.String(),
                    PostalCode = c.String(),
                    Region = c.String()
                })
                .PrimaryKey("PK_Supplier", t => t.SupplierID);

            migrationBuilder.CreateTable("Territory",
                c => new
                {
                    TerritoryID = c.String(),
                    TerritoryDescription = c.String()
                })
                .PrimaryKey("PK_Territory", t => t.TerritoryID);
        }

        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Customer");

            migrationBuilder.DropTable("Employee");

            migrationBuilder.DropTable("EmployeeTerritory");

            migrationBuilder.DropTable("Order");

            migrationBuilder.DropTable("OrderDetail");

            migrationBuilder.DropTable("Product");

            migrationBuilder.DropTable("Region");

            migrationBuilder.DropTable("Shipper");

            migrationBuilder.DropTable("Supplier");

            migrationBuilder.DropTable("Territory");
        }
    }
}