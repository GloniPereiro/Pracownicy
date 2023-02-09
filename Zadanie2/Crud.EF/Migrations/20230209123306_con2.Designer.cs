﻿// <auto-generated />
using Crud.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crud.EF.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20230209123306_con2")]
    partial class con2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crud.domain.Model.ListaPracownikow", b =>
                {
                    b.Property<int>("IdPracownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPracownika"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NiezakonczoneZadania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPracownika");

                    b.ToTable("ListaPracownikow");
                });

            modelBuilder.Entity("Crud.domain.Model.ListaZadan", b =>
                {
                    b.Property<int>("IdZadania")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZadania"));

                    b.Property<string>("KategoriaZadania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisZadania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pracownik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZadania");

                    b.ToTable("ListaZadan");
                });
#pragma warning restore 612, 618
        }
    }
}
