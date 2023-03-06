﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unik.SqlServerContext;

#nullable disable

namespace Unik.SqlServerContext.Migrations.Migrations
{
    [DbContext(typeof(UnikContext))]
    [Migration("20230306102757_Virker")]
    partial class Virker
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KompetenceEntityMedarbejderEntity", b =>
                {
                    b.Property<int>("KompetenceListeId")
                        .HasColumnType("int");

                    b.Property<int>("MedarbejderListeId")
                        .HasColumnType("int");

                    b.HasKey("KompetenceListeId", "MedarbejderListeId");

                    b.HasIndex("MedarbejderListeId");

                    b.ToTable("KompetenceEntityMedarbejderEntity");
                });

            modelBuilder.Entity("Unik.Domain.Booking.Model.BookingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MedarbejderId")
                        .HasColumnType("int");

                    b.Property<int>("OpgaveId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDato")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedarbejderId");

                    b.ToTable("Booking", "booking");
                });

            modelBuilder.Entity("Unik.Domain.Kompetence.Model.KompetenceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kompetence", "kompetence");
                });

            modelBuilder.Entity("Unik.Domain.Kunde.Model.KundeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Tlf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VirksomhedNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kunde", "kunde");
                });

            modelBuilder.Entity("Unik.Domain.Medarbejder.Model.MedarbejderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tlf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medarbejder", "medarbejder");
                });

            modelBuilder.Entity("Unik.Domain.Opgave.Model.OpgaveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjektId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Varighed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("ProjektId");

                    b.ToTable("Opgave", "opgave");
                });

            modelBuilder.Entity("Unik.Domain.Projekt.Model.ProjektEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AntalBoliger")
                        .HasColumnType("int");

                    b.Property<int>("KundeId")
                        .HasColumnType("int");

                    b.Property<string>("Noter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SalesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KundeId")
                        .IsUnique();

                    b.HasIndex("SalesId");

                    b.ToTable("ProjektEntities");
                });

            modelBuilder.Entity("Unik.Domain.Sales.Model.SalesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tlf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sales", "sales");
                });

            modelBuilder.Entity("KompetenceEntityMedarbejderEntity", b =>
                {
                    b.HasOne("Unik.Domain.Kompetence.Model.KompetenceEntity", null)
                        .WithMany()
                        .HasForeignKey("KompetenceListeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unik.Domain.Medarbejder.Model.MedarbejderEntity", null)
                        .WithMany()
                        .HasForeignKey("MedarbejderListeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Unik.Domain.Booking.Model.BookingEntity", b =>
                {
                    b.HasOne("Unik.Domain.Medarbejder.Model.MedarbejderEntity", "Medarbejder")
                        .WithMany("BookingListe")
                        .HasForeignKey("MedarbejderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medarbejder");
                });

            modelBuilder.Entity("Unik.Domain.Opgave.Model.OpgaveEntity", b =>
                {
                    b.HasOne("Unik.Domain.Booking.Model.BookingEntity", "booking")
                        .WithMany()
                        .HasForeignKey("BookingId");

                    b.HasOne("Unik.Domain.Projekt.Model.ProjektEntity", "Projekt")
                        .WithMany("Opgaver")
                        .HasForeignKey("ProjektId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projekt");

                    b.Navigation("booking");
                });

            modelBuilder.Entity("Unik.Domain.Projekt.Model.ProjektEntity", b =>
                {
                    b.HasOne("Unik.Domain.Kunde.Model.KundeEntity", "Kunde")
                        .WithOne("Projekt")
                        .HasForeignKey("Unik.Domain.Projekt.Model.ProjektEntity", "KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unik.Domain.Sales.Model.SalesEntity", "Sales")
                        .WithMany("ProjektListe")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunde");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Unik.Domain.Kunde.Model.KundeEntity", b =>
                {
                    b.Navigation("Projekt")
                        .IsRequired();
                });

            modelBuilder.Entity("Unik.Domain.Medarbejder.Model.MedarbejderEntity", b =>
                {
                    b.Navigation("BookingListe");
                });

            modelBuilder.Entity("Unik.Domain.Projekt.Model.ProjektEntity", b =>
                {
                    b.Navigation("Opgaver");
                });

            modelBuilder.Entity("Unik.Domain.Sales.Model.SalesEntity", b =>
                {
                    b.Navigation("ProjektListe");
                });
#pragma warning restore 612, 618
        }
    }
}