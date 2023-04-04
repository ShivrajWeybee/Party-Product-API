using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyProductAPI.Migrations
{
    public partial class added_identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Party",
            //    columns: table => new
            //    {
            //        PartyID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PartyName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Party", x => x.PartyID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        ProductID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Rate = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.ProductID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Invoice",
            //    columns: table => new
            //    {
            //        InvoiceID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PartyID = table.Column<int>(type: "int", nullable: false),
            //        ProductID = table.Column<int>(type: "int", nullable: false),
            //        Rate = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        Total = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
            //        table.ForeignKey(
            //            name: "FK_Invoice_Party_PartyID",
            //            column: x => x.PartyID,
            //            principalTable: "Party",
            //            principalColumn: "PartyID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Invoice_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Party_Product",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PartyID = table.Column<int>(type: "int", nullable: false),
            //        ProductID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Party_Product", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_PartyProduct_Party_PartyID",
            //            column: x => x.PartyID,
            //            principalTable: "Party",
            //            principalColumn: "PartyID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PartyProduct_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductRate",
            //    columns: table => new
            //    {
            //        PrtID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductID = table.Column<int>(type: "int", nullable: false),
            //        Rate = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
            //        DateOfRate = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductRate_PrtID", x => x.PrtID);
            //        table.ForeignKey(
            //            name: "FK_ProductRate_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Invoice_PartyID",
            //    table: "Invoice",
            //    column: "PartyID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Invoice_ProductID",
            //    table: "Invoice",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Party_Product_PartyID",
            //    table: "Party_Product",
            //    column: "PartyID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Party_Product_ProductID",
            //    table: "Party_Product",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductRate_ProductID",
            //    table: "ProductRate",
            //    column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Party_Product");

            migrationBuilder.DropTable(
                name: "ProductRate");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
