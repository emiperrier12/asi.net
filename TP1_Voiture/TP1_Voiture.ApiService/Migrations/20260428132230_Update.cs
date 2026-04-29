using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1_Voiture.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Voitures",
                newName: "Modele");

            migrationBuilder.AddColumn<string>(
                name: "Rue",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rue",
                table: "Loueurs");

            migrationBuilder.RenameColumn(
                name: "Modele",
                table: "Voitures",
                newName: "Model");
        }
    }
}
