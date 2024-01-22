using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EmployeesAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nit = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    nombre = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    fecha = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    estado = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    facturaId = table.Column<int>(type: "int", nullable: false),
                    producto = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    cantidad = table.Column<int>(type: "INT", nullable: false),
                    monto = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Facturas_facturaId",
                        column: x => x.facturaId,
                        principalTable: "Facturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_facturaId",
                table: "FacturaDetalle",
                column: "facturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
