using Debby.Admin.Sample.Models;
using Debby.Admin.Sample.Models.Northwind;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using System;

namespace Debby.Admin.Sample.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    public partial class NorthwindModel : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201412291824391_NorthwindModel";
            }
        }

        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta1-11518";
            }
        }

        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();

                builder.Entity("Debby.Admin.Sample.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount");
                        b.Property<string>("Email");
                        b.Property<bool>("EmailConfirmed");
                        b.Property<string>("Id");
                        b.Property<bool>("LockoutEnabled");
                        b.Property<DateTimeOffset>("LockoutEnd");
                        b.Property<string>("NormalizedUserName");
                        b.Property<string>("PasswordHash");
                        b.Property<string>("PhoneNumber");
                        b.Property<bool>("PhoneNumberConfirmed");
                        b.Property<string>("SecurityStamp");
                        b.Property<bool>("TwoFactorEnabled");
                        b.Property<string>("UserName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUsers");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Category", b =>
                    {
                        b.Property<int>("CategoryID")
                            .GenerateValuesOnAdd();
                        b.Property<string>("CategoryName");
                        b.Property<string>("Description");
                        b.Key("CategoryID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Customer", b =>
                    {
                        b.Property<string>("Address");
                        b.Property<string>("City");
                        b.Property<string>("CompanyName");
                        b.Property<string>("ContactName");
                        b.Property<string>("ContactTitle");
                        b.Property<string>("Country");
                        b.Property<string>("CustomerID");
                        b.Property<string>("Fax");
                        b.Property<string>("Phone");
                        b.Property<string>("PostalCode");
                        b.Property<string>("Region");
                        b.Key("CustomerID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Employee", b =>
                    {
                        b.Property<string>("Address");
                        b.Property<Nullable<DateTime>>("BirthDate");
                        b.Property<string>("City");
                        b.Property<string>("Country");
                        b.Property<int>("EmployeeID")
                            .GenerateValuesOnAdd();
                        b.Property<string>("Extension");
                        b.Property<string>("FirstName");
                        b.Property<Nullable<DateTime>>("HireDate");
                        b.Property<string>("HomePhone");
                        b.Property<string>("LastName");
                        b.Property<string>("Notes");
                        b.Property<Byte[]>("Photo");
                        b.Property<string>("PhotoPath");
                        b.Property<string>("PostalCode");
                        b.Property<string>("Region");
                        b.Property<Employee>("ReportsTo");
                        b.Property<string>("Title");
                        b.Property<string>("TitleOfCourtesy");
                        b.Key("EmployeeID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.EmployeeTerritory", b =>
                    {
                        b.Property<int>("EmployeeID");
                        b.Property<int>("EmployeeTerritoryID")
                            .GenerateValuesOnAdd();
                        b.Key("EmployeeTerritoryID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Order", b =>
                    {
                        b.Property<Nullable<short>>("Freight");
                        b.Property<Nullable<DateTime>>("OrderDate");
                        b.Property<int>("OrderID")
                            .GenerateValuesOnAdd();
                        b.Property<Nullable<DateTime>>("RequiredDate");
                        b.Property<string>("ShipAddress");
                        b.Property<string>("ShipCity");
                        b.Property<string>("ShipCountry");
                        b.Property<string>("ShipName");
                        b.Property<string>("ShipPostalCode");
                        b.Property<string>("ShipRegion");
                        b.Property<Nullable<DateTime>>("ShippedDate");
                        b.Key("OrderID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.OrderDetail", b =>
                    {
                        b.Property<float>("Discount");
                        b.Property<int>("OrderDetailId")
                            .GenerateValuesOnAdd();
                        b.Property<int>("OrderID");
                        b.Property<int>("ProductID");
                        b.Property<decimal>("Quantity");
                        b.Property<decimal>("UnitPrice");
                        b.Key("OrderDetailId");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Product", b =>
                    {
                        b.Property<bool>("Discontinued");
                        b.Property<int>("ProductID")
                            .GenerateValuesOnAdd();
                        b.Property<string>("ProductName");
                        b.Property<string>("QuantityPerUnit");
                        b.Property<Nullable<short>>("ReorderLevel");
                        b.Property<int>("SupplierID");
                        b.Property<decimal>("UnitPrice");
                        b.Property<Nullable<short>>("UnitsInStock");
                        b.Property<Nullable<short>>("UnitsOnOrder");
                        b.Key("ProductID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Region", b =>
                    {
                        b.Property<string>("RegionDescription");
                        b.Property<int>("RegionID")
                            .GenerateValuesOnAdd();
                        b.Key("RegionID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Shipper", b =>
                    {
                        b.Property<string>("CompanyName");
                        b.Property<string>("Phone");
                        b.Property<int>("ShipperID")
                            .GenerateValuesOnAdd();
                        b.Key("ShipperID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Supplier", b =>
                    {
                        b.Property<string>("Address");
                        b.Property<string>("City");
                        b.Property<string>("CompanyName");
                        b.Property<string>("ContactName");
                        b.Property<string>("ContactTitle");
                        b.Property<string>("Country");
                        b.Property<string>("Fax");
                        b.Property<string>("HomePage");
                        b.Property<string>("Phone");
                        b.Property<string>("PostalCode");
                        b.Property<string>("Region");
                        b.Property<int>("SupplierID")
                            .GenerateValuesOnAdd();
                        b.Key("SupplierID");
                    });

                builder.Entity("Debby.Admin.Sample.Models.Northwind.Territory", b =>
                    {
                        b.Property<string>("TerritoryDescription");
                        b.Property<string>("TerritoryID");
                        b.Key("TerritoryID");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityRole", b =>
                    {
                        b.Property<string>("Id");
                        b.Property<string>("Name");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoles");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValuesOnAdd();
                        b.Property<string>("RoleId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoleClaims");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValuesOnAdd();
                        b.Property<string>("UserId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUserClaims");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider");
                        b.Property<string>("ProviderDisplayName");
                        b.Property<string>("ProviderKey");
                        b.Property<string>("UserId");
                        b.Key("LoginProvider", "ProviderKey");
                        b.ForRelational().Table("AspNetUserLogins");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId");
                        b.Property<string>("UserId");
                        b.Key("UserId", "RoleId");
                        b.ForRelational().Table("AspNetUserRoles");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.IdentityRole", "RoleId");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Debby.Admin.Sample.Models.ApplicationUser", "UserId");
                    });

                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Debby.Admin.Sample.Models.ApplicationUser", "UserId");
                    });

                return builder.Model;
            }
        }
    }
}