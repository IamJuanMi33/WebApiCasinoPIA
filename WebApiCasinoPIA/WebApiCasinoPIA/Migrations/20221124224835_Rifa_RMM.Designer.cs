﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCasinoPIA;

#nullable disable

namespace WebApiCasinoPIA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221124224835_Rifa_RMM")]
    partial class RifaRMM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.ParticipanteRifa", b =>
                {
                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.Property<int>("RifaId")
                        .HasColumnType("int");

                    b.HasKey("ParticipanteId", "RifaId");

                    b.HasIndex("RifaId");

                    b.ToTable("ParticipantesRifas");
                });

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.Rifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rifas");
                });

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.ParticipanteRifa", b =>
                {
                    b.HasOne("WebApiCasinoPIA.Entidades.Participante", "Participante")
                        .WithMany("ParticipanteRifa")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCasinoPIA.Entidades.Rifa", "Rifa")
                        .WithMany("ParticipanteRifa")
                        .HasForeignKey("RifaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participante");

                    b.Navigation("Rifa");
                });

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.Participante", b =>
                {
                    b.Navigation("ParticipanteRifa");
                });

            modelBuilder.Entity("WebApiCasinoPIA.Entidades.Rifa", b =>
                {
                    b.Navigation("ParticipanteRifa");
                });
#pragma warning restore 612, 618
        }
    }
}
