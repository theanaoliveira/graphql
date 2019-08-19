﻿// <auto-generated />
using System;
using GraphQL.Infrastructure.PostgresDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQL.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190819160224_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GraphQL.Infrastructure.PostgresDataAccess.Entities.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Perfil","GraphQL");
                });

            modelBuilder.Entity("GraphQL.Infrastructure.PostgresDataAccess.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<Guid?>("PerfilId");

                    b.Property<double>("Salario");

                    b.Property<int>("Status");

                    b.Property<bool>("Vip");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario","GraphQL");
                });

            modelBuilder.Entity("GraphQL.Infrastructure.PostgresDataAccess.Entities.Usuario", b =>
                {
                    b.HasOne("GraphQL.Infrastructure.PostgresDataAccess.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");
                });
#pragma warning restore 612, 618
        }
    }
}