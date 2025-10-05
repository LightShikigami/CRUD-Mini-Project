using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Mini_Project.Migrations
{
    /// <inheritdoc />
    public partial class fixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_methodId",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameterId",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_typeId",
                table: "AnalysesRepository");

            migrationBuilder.AlterColumn<Guid>(
                name: "sample_typeId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "parameterId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "methodId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_methodId",
                table: "AnalysesRepository",
                column: "methodId",
                principalTable: "MethodsRepository",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameterId",
                table: "AnalysesRepository",
                column: "parameterId",
                principalTable: "ParametersRepository",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_typeId",
                table: "AnalysesRepository",
                column: "sample_typeId",
                principalTable: "SampleTypesRepository",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_methodId",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameterId",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_typeId",
                table: "AnalysesRepository");

            migrationBuilder.AlterColumn<Guid>(
                name: "sample_typeId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "parameterId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "methodId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_methodId",
                table: "AnalysesRepository",
                column: "methodId",
                principalTable: "MethodsRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameterId",
                table: "AnalysesRepository",
                column: "parameterId",
                principalTable: "ParametersRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_typeId",
                table: "AnalysesRepository",
                column: "sample_typeId",
                principalTable: "SampleTypesRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
