﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gerAcademic.Data;

namespace gerAcademic.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("gerAcademic.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("gerAcademic.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("gerAcademic.Models.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("double");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Prova");
                });

            modelBuilder.Entity("gerAcademic.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("gerAcademic.Models.Aluno", b =>
                {
                    b.HasOne("gerAcademic.Models.Evento", null)
                        .WithMany("Alunos")
                        .HasForeignKey("EventoId");

                    b.HasOne("gerAcademic.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("gerAcademic.Models.Prova", b =>
                {
                    b.HasOne("gerAcademic.Models.Aluno", "Aluno")
                        .WithMany("Provas")
                        .HasForeignKey("AlunoId");
                });
#pragma warning restore 612, 618
        }
    }
}
