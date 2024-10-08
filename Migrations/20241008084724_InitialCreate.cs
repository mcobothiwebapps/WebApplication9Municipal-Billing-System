using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication9Municipal_Billing_System.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regs", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tarriffs",
                columns: table => new
                {
                    TarriffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarriffs", x => x.TarriffId);
                });

            migrationBuilder.CreateTable(
                name: "electricities",
                columns: table => new
                {
                    ElectricityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electricities", x => x.ElectricityId);
                    table.ForeignKey(
                        name: "FK_electricities_Regs_RegUserId",
                        column: x => x.RegUserId,
                        principalTable: "Regs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "waters",
                columns: table => new
                {
                    WaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_waters", x => x.WaterId);
                    table.ForeignKey(
                        name: "FK_waters_Regs_RegUserId",
                        column: x => x.RegUserId,
                        principalTable: "Regs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WaterId = table.Column<int>(type: "int", nullable: false),
                    ElectricityId = table.Column<int>(type: "int", nullable: false),
                    TarriffId = table.Column<int>(type: "int", nullable: false),
                    BasicCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarriffDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_bills_electricities_ElectricityId",
                        column: x => x.ElectricityId,
                        principalTable: "electricities",
                        principalColumn: "ElectricityId");
                    table.ForeignKey(
                        name: "FK_bills_Regs_UserId",
                        column: x => x.UserId,
                        principalTable: "Regs",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_bills_tarriffs_TarriffId",
                        column: x => x.TarriffId,
                        principalTable: "tarriffs",
                        principalColumn: "TarriffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bills_waters_WaterId",
                        column: x => x.WaterId,
                        principalTable: "waters",
                        principalColumn: "WaterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bills_ElectricityId",
                table: "bills",
                column: "ElectricityId");

            migrationBuilder.CreateIndex(
                name: "IX_bills_TarriffId",
                table: "bills",
                column: "TarriffId");

            migrationBuilder.CreateIndex(
                name: "IX_bills_UserId",
                table: "bills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_bills_WaterId",
                table: "bills",
                column: "WaterId");

            migrationBuilder.CreateIndex(
                name: "IX_electricities_RegUserId",
                table: "electricities",
                column: "RegUserId");

            migrationBuilder.CreateIndex(
                name: "IX_waters_RegUserId",
                table: "waters",
                column: "RegUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "electricities");

            migrationBuilder.DropTable(
                name: "tarriffs");

            migrationBuilder.DropTable(
                name: "waters");

            migrationBuilder.DropTable(
                name: "Regs");
        }
    }
}
