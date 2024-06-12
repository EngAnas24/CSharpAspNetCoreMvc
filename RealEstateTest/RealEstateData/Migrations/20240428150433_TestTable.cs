using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class TestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balconys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balconys = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balconys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bathrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bathrooms = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bathrooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bedrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bedrooms = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<double>(type: "float", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "furnishedstatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Furnishedstatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furnishedstatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offertype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offertype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offertype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "propertystatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Propertystatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertystatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "propertytype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Propertytype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertytype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyprice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depositamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffertypeLiist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertytypeList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertystatusList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnishedstatusList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bedroomsList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bathroomsList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    balconysList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffertypeId = table.Column<int>(type: "int", nullable: false),
                    PropertytypeId = table.Column<int>(type: "int", nullable: false),
                    PropertystatusId = table.Column<int>(type: "int", nullable: false),
                    FurnishedstatusId = table.Column<int>(type: "int", nullable: false),
                    bedroomsId = table.Column<int>(type: "int", nullable: false),
                    bathroomsId = table.Column<int>(type: "int", nullable: false),
                    balconysId = table.Column<int>(type: "int", nullable: false),
                    carpetarea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalfloors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    floorroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertydescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesCounts = table.Column<int>(type: "int", nullable: false),
                    IsSaved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_Balconys_balconysId",
                        column: x => x.balconysId,
                        principalTable: "Balconys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_Bathrooms_bathroomsId",
                        column: x => x.bathroomsId,
                        principalTable: "Bathrooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_Bedrooms_bedroomsId",
                        column: x => x.bedroomsId,
                        principalTable: "Bedrooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_furnishedstatus_FurnishedstatusId",
                        column: x => x.FurnishedstatusId,
                        principalTable: "furnishedstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_offertype_OffertypeId",
                        column: x => x.OffertypeId,
                        principalTable: "offertype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_propertystatus_PropertystatusId",
                        column: x => x.PropertystatusId,
                        principalTable: "propertystatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_propertytype_PropertytypeId",
                        column: x => x.PropertytypeId,
                        principalTable: "propertytype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "savedProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    IsSaved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_savedProps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_savedProps_RealEstateProperty_PostId",
                        column: x => x.PostId,
                        principalTable: "RealEstateProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_balconysId",
                table: "RealEstateProperty",
                column: "balconysId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_bathroomsId",
                table: "RealEstateProperty",
                column: "bathroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_bedroomsId",
                table: "RealEstateProperty",
                column: "bedroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_FurnishedstatusId",
                table: "RealEstateProperty",
                column: "FurnishedstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_OffertypeId",
                table: "RealEstateProperty",
                column: "OffertypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_PropertystatusId",
                table: "RealEstateProperty",
                column: "PropertystatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_PropertytypeId",
                table: "RealEstateProperty",
                column: "PropertytypeId");

            migrationBuilder.CreateIndex(
                name: "IX_savedProps_PostId",
                table: "savedProps",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "savedProps");

            migrationBuilder.DropTable(
                name: "RealEstateProperty");

            migrationBuilder.DropTable(
                name: "Balconys");

            migrationBuilder.DropTable(
                name: "Bathrooms");

            migrationBuilder.DropTable(
                name: "Bedrooms");

            migrationBuilder.DropTable(
                name: "furnishedstatus");

            migrationBuilder.DropTable(
                name: "offertype");

            migrationBuilder.DropTable(
                name: "propertystatus");

            migrationBuilder.DropTable(
                name: "propertytype");
        }
    }
}
