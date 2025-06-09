using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicWorkManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diplomas_themes_ThemeId",
                table: "diplomas");

            migrationBuilder.DropForeignKey(
                name: "FK_diplomas_users_StudentId",
                table: "diplomas");

            migrationBuilder.DropForeignKey(
                name: "FK_files_diplomas_DiplomaId",
                table: "files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_themes",
                table: "themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_files",
                table: "files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diplomas",
                table: "diplomas");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "themes",
                newName: "Themes");

            migrationBuilder.RenameTable(
                name: "files",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "diplomas",
                newName: "Diplomas");

            migrationBuilder.RenameIndex(
                name: "IX_files_DiplomaId",
                table: "Files",
                newName: "IX_Files_DiplomaId");

            migrationBuilder.RenameIndex(
                name: "IX_diplomas_ThemeId",
                table: "Diplomas",
                newName: "IX_Diplomas_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_diplomas_StudentId",
                table: "Diplomas",
                newName: "IX_Diplomas_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Themes",
                table: "Themes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diplomas",
                table: "Diplomas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomas_Themes_ThemeId",
                table: "Diplomas",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomas_Users_StudentId",
                table: "Diplomas",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Diplomas_DiplomaId",
                table: "Files",
                column: "DiplomaId",
                principalTable: "Diplomas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomas_Themes_ThemeId",
                table: "Diplomas");

            migrationBuilder.DropForeignKey(
                name: "FK_Diplomas_Users_StudentId",
                table: "Diplomas");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Diplomas_DiplomaId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Themes",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diplomas",
                table: "Diplomas");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Themes",
                newName: "themes");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "files");

            migrationBuilder.RenameTable(
                name: "Diplomas",
                newName: "diplomas");

            migrationBuilder.RenameIndex(
                name: "IX_Files_DiplomaId",
                table: "files",
                newName: "IX_files_DiplomaId");

            migrationBuilder.RenameIndex(
                name: "IX_Diplomas_ThemeId",
                table: "diplomas",
                newName: "IX_diplomas_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Diplomas_StudentId",
                table: "diplomas",
                newName: "IX_diplomas_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_themes",
                table: "themes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_files",
                table: "files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diplomas",
                table: "diplomas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diplomas_themes_ThemeId",
                table: "diplomas",
                column: "ThemeId",
                principalTable: "themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_diplomas_users_StudentId",
                table: "diplomas",
                column: "StudentId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_files_diplomas_DiplomaId",
                table: "files",
                column: "DiplomaId",
                principalTable: "diplomas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
