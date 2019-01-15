﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto2List.Api.Data;

namespace Projeto2List.Api.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    partial class StoreDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto2List.Api.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCreate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<int>("IdNotaTarefa");

                    b.Property<int?>("NotaTarefaId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("NotaTarefaId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Projeto2List.Api.Models.NotaTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("NotaTarefa");
                });

            modelBuilder.Entity("Projeto2List.Api.Models.Item", b =>
                {
                    b.HasOne("Projeto2List.Api.Models.NotaTarefa", "NotaTarefa")
                        .WithMany("Itens")
                        .HasForeignKey("NotaTarefaId");
                });
#pragma warning restore 612, 618
        }
    }
}