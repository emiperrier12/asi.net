using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1_Voiture.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_j_location_loc_Loueurs_lou_id",
                table: "t_j_location_loc");

            migrationBuilder.DropForeignKey(
                name: "FK_t_j_location_loc_Voitures_voi_id",
                table: "t_j_location_loc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loueurs",
                table: "Loueurs");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "t_e_voiture_voi");

            migrationBuilder.RenameTable(
                name: "Loueurs",
                newName: "t_e_loueur_lou");

            migrationBuilder.RenameColumn(
                name: "PrixLocationParJour",
                table: "t_e_voiture_voi",
                newName: "voi_prixlocationparjour");

            migrationBuilder.RenameColumn(
                name: "Modele",
                table: "t_e_voiture_voi",
                newName: "voi_modele");

            migrationBuilder.RenameColumn(
                name: "Marque",
                table: "t_e_voiture_voi",
                newName: "voi_marque");

            migrationBuilder.RenameColumn(
                name: "Immatriculation",
                table: "t_e_voiture_voi",
                newName: "voi_immatriculation");

            migrationBuilder.RenameColumn(
                name: "Categorie",
                table: "t_e_voiture_voi",
                newName: "voi_categorie");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "t_e_voiture_voi",
                newName: "voi_id");

            migrationBuilder.RenameColumn(
                name: "Ville",
                table: "t_e_loueur_lou",
                newName: "lou_ville");

            migrationBuilder.RenameColumn(
                name: "Rue",
                table: "t_e_loueur_lou",
                newName: "lou_rue");

            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "t_e_loueur_lou",
                newName: "lou_prenom");

            migrationBuilder.RenameColumn(
                name: "Pays",
                table: "t_e_loueur_lou",
                newName: "lou_pays");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "t_e_loueur_lou",
                newName: "lou_nom");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "t_e_loueur_lou",
                newName: "lou_mobile");

            migrationBuilder.RenameColumn(
                name: "Cp",
                table: "t_e_loueur_lou",
                newName: "lou_cp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "t_e_loueur_lou",
                newName: "lou_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "voi_prixlocationparjour",
                table: "t_e_voiture_voi",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "voi_modele",
                table: "t_e_voiture_voi",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "voi_marque",
                table: "t_e_voiture_voi",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "voi_immatriculation",
                table: "t_e_voiture_voi",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "voi_categorie",
                table: "t_e_voiture_voi",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lou_ville",
                table: "t_e_loueur_lou",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_rue",
                table: "t_e_loueur_lou",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_prenom",
                table: "t_e_loueur_lou",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_pays",
                table: "t_e_loueur_lou",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_nom",
                table: "t_e_loueur_lou",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_mobile",
                table: "t_e_loueur_lou",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lou_cp",
                table: "t_e_loueur_lou",
                type: "character varying(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_voiture_voi",
                table: "t_e_voiture_voi",
                column: "voi_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_loueur_lou",
                table: "t_e_loueur_lou",
                column: "lou_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_location_loc_t_e_loueur_lou_lou_id",
                table: "t_j_location_loc",
                column: "lou_id",
                principalTable: "t_e_loueur_lou",
                principalColumn: "lou_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_location_loc_t_e_voiture_voi_voi_id",
                table: "t_j_location_loc",
                column: "voi_id",
                principalTable: "t_e_voiture_voi",
                principalColumn: "voi_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_j_location_loc_t_e_loueur_lou_lou_id",
                table: "t_j_location_loc");

            migrationBuilder.DropForeignKey(
                name: "FK_t_j_location_loc_t_e_voiture_voi_voi_id",
                table: "t_j_location_loc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_voiture_voi",
                table: "t_e_voiture_voi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_loueur_lou",
                table: "t_e_loueur_lou");

            migrationBuilder.RenameTable(
                name: "t_e_voiture_voi",
                newName: "Voitures");

            migrationBuilder.RenameTable(
                name: "t_e_loueur_lou",
                newName: "Loueurs");

            migrationBuilder.RenameColumn(
                name: "voi_prixlocationparjour",
                table: "Voitures",
                newName: "PrixLocationParJour");

            migrationBuilder.RenameColumn(
                name: "voi_modele",
                table: "Voitures",
                newName: "Modele");

            migrationBuilder.RenameColumn(
                name: "voi_marque",
                table: "Voitures",
                newName: "Marque");

            migrationBuilder.RenameColumn(
                name: "voi_immatriculation",
                table: "Voitures",
                newName: "Immatriculation");

            migrationBuilder.RenameColumn(
                name: "voi_categorie",
                table: "Voitures",
                newName: "Categorie");

            migrationBuilder.RenameColumn(
                name: "voi_id",
                table: "Voitures",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "lou_ville",
                table: "Loueurs",
                newName: "Ville");

            migrationBuilder.RenameColumn(
                name: "lou_rue",
                table: "Loueurs",
                newName: "Rue");

            migrationBuilder.RenameColumn(
                name: "lou_prenom",
                table: "Loueurs",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "lou_pays",
                table: "Loueurs",
                newName: "Pays");

            migrationBuilder.RenameColumn(
                name: "lou_nom",
                table: "Loueurs",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "lou_mobile",
                table: "Loueurs",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "lou_cp",
                table: "Loueurs",
                newName: "Cp");

            migrationBuilder.RenameColumn(
                name: "lou_id",
                table: "Loueurs",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixLocationParJour",
                table: "Voitures",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Modele",
                table: "Voitures",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Marque",
                table: "Voitures",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Immatriculation",
                table: "Voitures",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Categorie",
                table: "Voitures",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rue",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pays",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Loueurs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cp",
                table: "Loueurs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loueurs",
                table: "Loueurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_location_loc_Loueurs_lou_id",
                table: "t_j_location_loc",
                column: "lou_id",
                principalTable: "Loueurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_location_loc_Voitures_voi_id",
                table: "t_j_location_loc",
                column: "voi_id",
                principalTable: "Voitures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
