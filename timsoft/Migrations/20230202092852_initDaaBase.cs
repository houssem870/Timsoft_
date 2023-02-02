using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace timsoft.Migrations
{
    public partial class initDaaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Réclamation",
                columns: table => new
                {
                    IdReclam = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Objet = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Réclamation", x => x.IdReclam);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    IdReponse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Flag = table.Column<string>(type: "text", nullable: true),
                    NpRep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.IdReponse);
                });

            migrationBuilder.CreateTable(
                name: "Rôle",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rôle", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Type_Epreuve",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Epreuve", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prénom = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    IdQuest = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Intitule = table.Column<string>(type: "text", nullable: false),
                    Durée = table.Column<int>(type: "integer", nullable: false),
                    Catégorie = table.Column<string>(type: "text", nullable: false),
                    Point = table.Column<int>(type: "integer", nullable: false),
                    NbRep = table.Column<int>(type: "integer", nullable: false),
                    ReponseIdReponse = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.IdQuest);
                    table.ForeignKey(
                        name: "FK_Question_Reponse_ReponseIdReponse",
                        column: x => x.ReponseIdReponse,
                        principalTable: "Reponse",
                        principalColumn: "IdReponse");
                });

            migrationBuilder.CreateTable(
                name: "Epreuve",
                columns: table => new
                {
                    IdEpreuve = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEpreuve = table.Column<string>(type: "text", nullable: true),
                    Duree = table.Column<int>(type: "integer", nullable: false),
                    SommePoints = table.Column<int>(type: "integer", nullable: false),
                    Complexité = table.Column<string>(type: "text", nullable: true),
                    Type_EpreuvesIdType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epreuve", x => x.IdEpreuve);
                    table.ForeignKey(
                        name: "FK_Epreuve_Type_Epreuve_Type_EpreuvesIdType",
                        column: x => x.Type_EpreuvesIdType,
                        principalTable: "Type_Epreuve",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    IdInv = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_inv = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    UserIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.IdInv);
                    table.ForeignKey(
                        name: "FK_Invitation_User_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epreuve_Type_EpreuvesIdType",
                table: "Epreuve",
                column: "Type_EpreuvesIdType");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_UserIdUser",
                table: "Invitation",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ReponseIdReponse",
                table: "Question",
                column: "ReponseIdReponse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Epreuve");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Réclamation");

            migrationBuilder.DropTable(
                name: "Rôle");

            migrationBuilder.DropTable(
                name: "Type_Epreuve");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Reponse");
        }
    }
}
