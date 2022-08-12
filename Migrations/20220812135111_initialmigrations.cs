using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class initialmigrations : Migration
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
                name: "client",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    c_homeaddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.c_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    acc_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    acc_clientid = table.Column<int>(type: "int(11)", nullable: false),
                    acc_type_id = table.Column<int>(type: "int(11)", nullable: false),
                    acc_balance = table.Column<decimal>(type: "decimals(5,2)", precision: 5, scale: 2, nullable: false),
                    acc_interestapplieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.acc_id);
                    table.ForeignKey(
                        name: "account_ibfk_1",
                        column: x => x.acc_clientid,
                        principalTable: "client",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "account_ibfk_2",
                        column: x => x.acc_type_id,
                        principalTable: "accounttype",
                        principalColumn: "at_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "accounttype",
                columns: new[] { "at_id", "at_interestrate", "at_name" },
                values: new object[,]
                {
                    { -3, 1.25m, "Standard Saving" },
                    { -2, 3.69m, "Standard Saving" },
                    { -1, 0.75m, "Standard Saving" }
                });

            migrationBuilder.InsertData(
                table: "client",
                columns: new[] { "c_id", "c_birthdate", "c_firstname", "c_homeaddress", "c_lastname" },
                values: new object[,]
                {
                    { -4, new DateTime(1968, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Callie", "012 Cedarwood Way", "Whittington" },
                    { -3, new DateTime(1968, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles", "789 Maplewood Way", "Sheen" },
                    { -2, new DateTime(1968, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zac", "456 Pecanwood Way", "Ingram" },
                    { -1, new DateTime(1955, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borat", "12345-123 St North, Cincinatti, OH, 87542", "Sagdiyev" }
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "acc_id", "acc_balance", "acc_clientid", "acc_interestapplieddate", "acc_type_id" },
                values: new object[,]
                {
                    { -6, 109656m, -1, new DateTime(2004, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -3 },
                    { -5, 345000m, -2, new DateTime(2018, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -3 },
                    { -4, 5000m, -2, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 },
                    { -3, 99000m, -1, new DateTime(2015, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 },
                    { -2, 25000m, -2, new DateTime(2010, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 },
                    { -1, 165000m, -1, new DateTime(1979, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 }
                });

            migrationBuilder.CreateIndex(
                name: "acc_clientid",
                table: "account",
                column: "acc_clientid");

            migrationBuilder.CreateIndex(
                name: "acc_type_id",
                table: "account",
                column: "acc_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "accounttype");
        }
    }
}
