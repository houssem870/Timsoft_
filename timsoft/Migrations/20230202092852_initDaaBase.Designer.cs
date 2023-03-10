// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using timsoft.DataBase;

#nullable disable

namespace timsoft.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230202092852_initDaaBase")]
    partial class initDaaBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("timsoft.entities.Epreuve", b =>
                {
                    b.Property<int>("IdEpreuve")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEpreuve"));

                    b.Property<string>("Complexité")
                        .HasColumnType("text");

                    b.Property<int>("Duree")
                        .HasColumnType("integer");

                    b.Property<string>("NomEpreuve")
                        .HasColumnType("text");

                    b.Property<int>("SommePoints")
                        .HasColumnType("integer");

                    b.Property<int>("Type_EpreuvesIdType")
                        .HasColumnType("integer");

                    b.HasKey("IdEpreuve");

                    b.HasIndex("Type_EpreuvesIdType");

                    b.ToTable("Epreuve");
                });

            modelBuilder.Entity("timsoft.entities.Invitation", b =>
                {
                    b.Property<int>("IdInv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdInv"));

                    b.Property<int>("UserIdUser")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date_inv")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.HasKey("IdInv");

                    b.HasIndex("UserIdUser");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("timsoft.entities.Question", b =>
                {
                    b.Property<int>("IdQuest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdQuest"));

                    b.Property<string>("Catégorie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Durée")
                        .HasColumnType("integer");

                    b.Property<string>("Intitule")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NbRep")
                        .HasColumnType("integer");

                    b.Property<int>("Point")
                        .HasColumnType("integer");

                    b.Property<int?>("ReponseIdReponse")
                        .HasColumnType("integer");

                    b.HasKey("IdQuest");

                    b.HasIndex("ReponseIdReponse");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("timsoft.entities.Réclamation", b =>
                {
                    b.Property<int>("IdReclam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdReclam"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Objet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdReclam");

                    b.ToTable("Réclamation");
                });

            modelBuilder.Entity("timsoft.entities.Reponse", b =>
                {
                    b.Property<int>("IdReponse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdReponse"));

                    b.Property<string>("Flag")
                        .HasColumnType("text");

                    b.Property<int>("NpRep")
                        .HasColumnType("integer");

                    b.HasKey("IdReponse");

                    b.ToTable("Reponse");
                });

            modelBuilder.Entity("timsoft.entities.Rôle", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRole"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdRole");

                    b.ToTable("Rôle");
                });

            modelBuilder.Entity("timsoft.entities.Type_Epreuve", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdType"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdType");

                    b.ToTable("Type_Epreuve");
                });

            modelBuilder.Entity("timsoft.entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<string>("Prénom")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("timsoft.entities.Epreuve", b =>
                {
                    b.HasOne("timsoft.entities.Type_Epreuve", "Type_Epreuves")
                        .WithMany()
                        .HasForeignKey("Type_EpreuvesIdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type_Epreuves");
                });

            modelBuilder.Entity("timsoft.entities.Invitation", b =>
                {
                    b.HasOne("timsoft.entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("timsoft.entities.Question", b =>
                {
                    b.HasOne("timsoft.entities.Reponse", null)
                        .WithMany("Questions")
                        .HasForeignKey("ReponseIdReponse");
                });

            modelBuilder.Entity("timsoft.entities.Reponse", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
