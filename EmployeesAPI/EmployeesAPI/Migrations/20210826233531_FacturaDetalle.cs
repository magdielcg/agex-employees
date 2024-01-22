using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesAPI.Migrations
{
    public partial class FacturaDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalles_Facturas_facturaId",
                table: "FacturaDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaDetalles",
                table: "FacturaDetalles");

            migrationBuilder.RenameTable(
                name: "Facturas",
                newName: "Factura");

            migrationBuilder.RenameTable(
                name: "FacturaDetalles",
                newName: "FacturaDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_FacturaDetalles_facturaId",
                table: "FacturaDetalle",
                newName: "IX_FacturaDetalle_facturaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura",
                table: "Factura",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaDetalle",
                table: "FacturaDetalle",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalle_Factura_facturaId",
                table: "FacturaDetalle",
                column: "facturaId",
                principalTable: "Factura",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalle_Factura_facturaId",
                table: "FacturaDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaDetalle",
                table: "FacturaDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura",
                table: "Factura");

            migrationBuilder.RenameTable(
                name: "FacturaDetalle",
                newName: "FacturaDetalles");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "Facturas");

            migrationBuilder.RenameIndex(
                name: "IX_FacturaDetalle_facturaId",
                table: "FacturaDetalles",
                newName: "IX_FacturaDetalles_facturaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaDetalles",
                table: "FacturaDetalles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalles_Facturas_facturaId",
                table: "FacturaDetalles",
                column: "facturaId",
                principalTable: "Facturas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
