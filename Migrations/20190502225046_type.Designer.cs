﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_college.Models;

namespace Project_college.Migrations
{
    [DbContext(typeof(EtudiantContext))]
    [Migration("20190502225046_type")]
    partial class type
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project_college.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EtudiantId");

                    b.HasKey("AbsenceId");

                    b.HasIndex("CourId");

                    b.HasIndex("EtudiantId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("Project_college.Models.Classe", b =>
                {
                    b.Property<int>("ClasseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nbrPlace")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("niveau")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ClasseId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Project_college.Models.Cour", b =>
                {
                    b.Property<int>("CourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnseignantId");

                    b.Property<int>("SalleId");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(20);

                    b.HasKey("CourId");

                    b.HasIndex("EnseignantId");

                    b.HasIndex("SalleId");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("Project_college.Models.Enseignant", b =>
                {
                    b.Property<int>("EnseignantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(8);

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(20);

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(20);

                    b.HasKey("EnseignantId");

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("Project_college.Models.Enseigne", b =>
                {
                    b.Property<int>("EnseigneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasseId");

                    b.Property<int>("EnseignantId");

                    b.HasKey("EnseigneId");

                    b.HasIndex("ClasseId");

                    b.HasIndex("EnseignantId");

                    b.ToTable("Enseignes");
                });

            modelBuilder.Entity("Project_college.Models.Etudiant", b =>
                {
                    b.Property<int>("EtudiantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(20);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(20);

                    b.Property<string>("cin")
                        .HasMaxLength(8);

                    b.HasKey("EtudiantId");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("Project_college.Models.Salle", b =>
                {
                    b.Property<int>("SalleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TypeId");

                    b.Property<int>("numero")
                        .HasMaxLength(20);

                    b.HasKey("SalleId");

                    b.HasIndex("TypeId");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("Project_college.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("TypeId");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Project_college.Models.Absence", b =>
                {
                    b.HasOne("Project_college.Models.Cour", "Cour")
                        .WithMany("Absences")
                        .HasForeignKey("CourId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_college.Models.Etudiant", "Etudiant")
                        .WithMany("Absences")
                        .HasForeignKey("EtudiantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_college.Models.Cour", b =>
                {
                    b.HasOne("Project_college.Models.Enseignant", "Enseignant")
                        .WithMany("Cours")
                        .HasForeignKey("EnseignantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_college.Models.Salle", "Salle")
                        .WithMany("Cours")
                        .HasForeignKey("SalleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_college.Models.Enseigne", b =>
                {
                    b.HasOne("Project_college.Models.Classe", "Classe")
                        .WithMany("Enseignes")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_college.Models.Enseignant", "Enseignant")
                        .WithMany()
                        .HasForeignKey("EnseignantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_college.Models.Salle", b =>
                {
                    b.HasOne("Project_college.Models.Type", "type")
                        .WithMany("Salles")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
