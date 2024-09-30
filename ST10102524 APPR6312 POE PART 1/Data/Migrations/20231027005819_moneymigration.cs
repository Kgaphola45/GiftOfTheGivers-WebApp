﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10102524_APPR6312_POE_PART_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class moneymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Money",
              columns: table => new
              {
                  MoneyId = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                  RemainingMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Money", x => x.MoneyId);
              });

            migrationBuilder.Sql("SET IDENTITY_INSERT Money ON");

            // Insert your record with explicit MoneyId here
            migrationBuilder.InsertData(
                table: "Money",
                columns: new[] { "MoneyId", "TotalMoney", "RemainingMoney" },
                values: new object[] { 1, 0.00, 0.00 });

            migrationBuilder.Sql("SET IDENTITY_INSERT Money OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
