using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orchard.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "HARVEST_SEQ");

            migrationBuilder.CreateSequence<int>(
                name: "SPECIE_SEQ");

            migrationBuilder.CreateSequence<int>(
                name: "TREE_SEQ");

            migrationBuilder.CreateSequence<int>(
                name: "TREEGROUP_SEQ");

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TreeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    SpecieId = table.Column<int>(nullable: false),
                    TreeGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trees_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreeGroups_TreeGroupId",
                        column: x => x.TreeGroupId,
                        principalTable: "TreeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    GrossWeight = table.Column<decimal>(nullable: false),
                    TreeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvests_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_TreeId",
                table: "Harvests",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_SpecieId",
                table: "Trees",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_TreeGroupId",
                table: "Trees",
                column: "TreeGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "TreeGroups");

            migrationBuilder.DropSequence(
                name: "HARVEST_SEQ");

            migrationBuilder.DropSequence(
                name: "SPECIE_SEQ");

            migrationBuilder.DropSequence(
                name: "TREE_SEQ");

            migrationBuilder.DropSequence(
                name: "TREEGROUP_SEQ");
        }
    }
}
