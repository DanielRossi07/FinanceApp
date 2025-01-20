using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.Data.EF.Migrations
{
    public partial class AlterTransactionSourceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Type",
            table: "TransactionSources",
            type: "varchar(50)",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Type",
            table: "TransactionSources",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
