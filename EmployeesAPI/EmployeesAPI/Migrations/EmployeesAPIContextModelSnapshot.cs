﻿// <auto-generated />
using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeesAPI.Migrations
{
    [DbContext(typeof(EmployeesAPIContext))]
    partial class EmployeesAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("EmployeesAPI.Models.Factura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("INT");

                    b.Property<string>("fecha")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("nit")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("nombre")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("id");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("EmployeesAPI.Models.FacturaDetalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("INT");

                    b.Property<int>("facturaId")
                        .HasColumnType("int");

                    b.Property<decimal>("monto")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<string>("producto")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("total")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("id");

                    b.HasIndex("facturaId");

                    b.ToTable("FacturaDetalle");
                });

            modelBuilder.Entity("EmployeesAPI.Models.FacturaDetalle", b =>
                {
                    b.HasOne("EmployeesAPI.Models.Factura", null)
                        .WithMany("detalle")
                        .HasForeignKey("facturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesAPI.Models.Factura", b =>
                {
                    b.Navigation("detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
