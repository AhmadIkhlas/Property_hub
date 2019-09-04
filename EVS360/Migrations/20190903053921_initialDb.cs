using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVS360.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginId = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    SecurityQuestion = table.Column<string>(type: "varchar(255)", nullable: true),
                    SecurityAnswer = table.Column<string>(type: "varchar(255)", nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousingSchemes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemeBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    NeighborhoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemeBlocks_HousingSchemes_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "HousingSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAdvs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    StartsOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AdvTypeId = table.Column<int>(nullable: false),
                    AdvStatusId = table.Column<int>(nullable: false),
                    SchemeBlockId = table.Column<int>(nullable: false),
                    PostedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAdvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_AdvStatus_AdvStatusId",
                        column: x => x.AdvStatusId,
                        principalTable: "AdvStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_AdvTypes_AdvTypeId",
                        column: x => x.AdvTypeId,
                        principalTable: "AdvTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_Users_PostedById",
                        column: x => x.PostedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_SchemeBlocks_SchemeBlockId",
                        column: x => x.SchemeBlockId,
                        principalTable: "SchemeBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAdvsPropertyFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisementId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAdvsPropertyFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAdvsPropertyFeatures_PropertyAdvs_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvsPropertyFeatures_PropertyFeature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "PropertyFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    PropertyAdvId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyArea_PropertyAdvs_PropertyAdvId",
                        column: x => x.PropertyAdvId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyArea_AreaUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AreaUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(300)", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    PropertyAdvId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImage_PropertyAdvs_PropertyAdvId",
                        column: x => x.PropertyAdvId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_HousingSchemes_CityId",
                table: "HousingSchemes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_AdvStatusId",
                table: "PropertyAdvs",
                column: "AdvStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_AdvTypeId",
                table: "PropertyAdvs",
                column: "AdvTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_PostedById",
                table: "PropertyAdvs",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_SchemeBlockId",
                table: "PropertyAdvs",
                column: "SchemeBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvsPropertyFeatures_AdvertisementId",
                table: "PropertyAdvsPropertyFeatures",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvsPropertyFeatures_FeatureId",
                table: "PropertyAdvsPropertyFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyArea_PropertyAdvId",
                table: "PropertyArea",
                column: "PropertyAdvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyArea_UnitId",
                table: "PropertyArea",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyAdvId",
                table: "PropertyImage",
                column: "PropertyAdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeBlocks_NeighborhoodId",
                table: "SchemeBlocks",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PropertyAdvsPropertyFeatures");

            migrationBuilder.DropTable(
                name: "PropertyArea");

            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyFeature");

            migrationBuilder.DropTable(
                name: "AreaUnits");

            migrationBuilder.DropTable(
                name: "PropertyAdvs");

            migrationBuilder.DropTable(
                name: "AdvStatus");

            migrationBuilder.DropTable(
                name: "AdvTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SchemeBlocks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "HousingSchemes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
