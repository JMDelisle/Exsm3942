using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accounttype",
                columns: table => new
                {
                    at_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    at_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    at_interestrate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.at_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    acc_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    acc_client_id = table.Column<int>(type: "int(11)", nullable: false),
                    acc_type_id = table.Column<int>(type: "int(11)", nullable: false),
                    acc_balance = table.Column<decimal>(type: "decimals(5,2)", precision: 5, scale: 2, nullable: false),
                    acc_interestapplieddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    acc_appliedinterest = table.Column<int>(type: "int(11)", nullable: false),
                    acc_deposit = table.Column<decimal>(type: "decimal(10,0)", precision: 10, nullable: false),
                    acc_withdraw = table.Column<decimal>(type: "decimal(10,0)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.acc_id);
                    table.ForeignKey(
                        name: "account_ibfk_2",
                        column: x => x.acc_type_id,
                        principalTable: "accounttype",
                        principalColumn: "at_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int(11)", nullable: false),
                    c_firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    c_homeaddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.c_id);
                    table.ForeignKey(
                        name: "client_ibfk_1",
                        column: x => x.c_id,
                        principalTable: "account",
                        principalColumn: "acc_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "acc_client_id",
                table: "account",
                column: "acc_client_id");

            migrationBuilder.CreateIndex(
                name: "acc_type_id",
                table: "account",
                column: "acc_type_id");

            migrationBuilder.AddForeignKey(
                name: "account_ibfk_1",
                table: "account",
                column: "acc_client_id",
                principalTable: "client",
                principalColumn: "c_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "account_ibfk_1",
                table: "account");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "accounttype");
        }
    }
}
