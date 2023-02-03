using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timsoft.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Reponse_ReponseIdReponse",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ReponseIdReponse",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ReponseIdReponse",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "RôleIdRole",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Type_Epreuve",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Rôle",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "ReponseQuest",
                columns: table => new
                {
                    QuestionIdQuest = table.Column<int>(type: "integer", nullable: false),
                    ReponseIdReponse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseQuest", x => new { x.QuestionIdQuest, x.ReponseIdReponse });
                    table.ForeignKey(
                        name: "FK_ReponseQuest_Question_QuestionIdQuest",
                        column: x => x.QuestionIdQuest,
                        principalTable: "Question",
                        principalColumn: "IdQuest",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReponseQuest_Reponse_ReponseIdReponse",
                        column: x => x.ReponseIdReponse,
                        principalTable: "Reponse",
                        principalColumn: "IdReponse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REpreuveQuest",
                columns: table => new
                {
                    EpreuveIdEpreuve = table.Column<int>(type: "integer", nullable: false),
                    QuestionIdQuest = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REpreuveQuest", x => new { x.EpreuveIdEpreuve, x.QuestionIdQuest });
                    table.ForeignKey(
                        name: "FK_REpreuveQuest_Epreuve_EpreuveIdEpreuve",
                        column: x => x.EpreuveIdEpreuve,
                        principalTable: "Epreuve",
                        principalColumn: "IdEpreuve",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REpreuveQuest_Question_QuestionIdQuest",
                        column: x => x.QuestionIdQuest,
                        principalTable: "Question",
                        principalColumn: "IdQuest",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEpreuve",
                columns: table => new
                {
                    IdEpreuve = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Resultat = table.Column<string>(type: "text", nullable: true),
                    date_lim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEpreuve", x => new { x.IdUser, x.IdEpreuve });
                    table.ForeignKey(
                        name: "FK_UserEpreuve_Epreuve_IdEpreuve",
                        column: x => x.IdEpreuve,
                        principalTable: "Epreuve",
                        principalColumn: "IdEpreuve",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEpreuve_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReclam",
                columns: table => new
                {
                    RéclamationIdReclam = table.Column<int>(type: "integer", nullable: false),
                    UsersIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReclam", x => new { x.RéclamationIdReclam, x.UsersIdUser });
                    table.ForeignKey(
                        name: "FK_UserReclam_Réclamation_RéclamationIdReclam",
                        column: x => x.RéclamationIdReclam,
                        principalTable: "Réclamation",
                        principalColumn: "IdReclam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReclam_User_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RôleIdRole",
                table: "User",
                column: "RôleIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_ReponseQuest_ReponseIdReponse",
                table: "ReponseQuest",
                column: "ReponseIdReponse");

            migrationBuilder.CreateIndex(
                name: "IX_REpreuveQuest_QuestionIdQuest",
                table: "REpreuveQuest",
                column: "QuestionIdQuest");

            migrationBuilder.CreateIndex(
                name: "IX_UserEpreuve_IdEpreuve",
                table: "UserEpreuve",
                column: "IdEpreuve");

            migrationBuilder.CreateIndex(
                name: "IX_UserReclam_UsersIdUser",
                table: "UserReclam",
                column: "UsersIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rôle_RôleIdRole",
                table: "User",
                column: "RôleIdRole",
                principalTable: "Rôle",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Rôle_RôleIdRole",
                table: "User");

            migrationBuilder.DropTable(
                name: "ReponseQuest");

            migrationBuilder.DropTable(
                name: "REpreuveQuest");

            migrationBuilder.DropTable(
                name: "UserEpreuve");

            migrationBuilder.DropTable(
                name: "UserReclam");

            migrationBuilder.DropIndex(
                name: "IX_User_RôleIdRole",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RôleIdRole",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Type_Epreuve",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Rôle",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReponseIdReponse",
                table: "Question",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ReponseIdReponse",
                table: "Question",
                column: "ReponseIdReponse");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Reponse_ReponseIdReponse",
                table: "Question",
                column: "ReponseIdReponse",
                principalTable: "Reponse",
                principalColumn: "IdReponse");
        }
    }
}
