using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.Data.EF.Migrations
{
    public partial class CreateTransactionSourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories");

            migrationBuilder.RenameTable(
                name: "TransactionCategories",
                newName: "TransactionCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategory",
                table: "TransactionCategory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TransactionSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankAccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionSources_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSources_BankAccountId",
                table: "TransactionSources",
                column: "BankAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategory",
                table: "TransactionCategory");

            migrationBuilder.RenameTable(
                name: "TransactionCategory",
                newName: "TransactionCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories",
                column: "Id");
        }
    }
}
