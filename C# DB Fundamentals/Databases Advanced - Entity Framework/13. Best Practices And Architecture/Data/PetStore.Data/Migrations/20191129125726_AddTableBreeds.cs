using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class AddTableBreeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breed_BreedId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breed",
                table: "Breed");

            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds");

            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breed",
                table: "Breed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breed_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
