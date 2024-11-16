﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFMobile.Services;

#nullable disable

namespace WPFMobile.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241116155227_PacienteIdade")]
    partial class PacienteIdade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WPFMobile.PacienteModel", b =>
                {
                    b.Property<int>("pacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pacienteId"));

                    b.Property<string>("pacienteCpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pacienteEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pacienteIdade")
                        .HasColumnType("int");

                    b.Property<string>("pacienteNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pacienteSexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pacienteTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pacienteId");

                    b.ToTable("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
