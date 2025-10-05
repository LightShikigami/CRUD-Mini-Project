using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Mini_Project.Migrations
{
    /// <inheritdoc />
    public partial class foreigkeyIds : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_methodId",
                table: "AnalysesRepository");

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_parameterId",
                table: "AnalysesRepository");

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_sample_typeId",
                table: "AnalysesRepository");

            migrationBuilder.DropColumn(
                name: "methodId",
                table: "AnalysesRepository");

            migrationBuilder.DropColumn(
                name: "parameterId",
                table: "AnalysesRepository");

            migrationBuilder.DropColumn(
                name: "sample_typeId",
                table: "AnalysesRepository");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_method_id",
                table: "AnalysesRepository",
                column: "method_id");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_parameter_id",
                table: "AnalysesRepository",
                column: "parameter_id");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_sample_type_id",
                table: "AnalysesRepository",
                column: "sample_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_method_id",
                table: "AnalysesRepository",
                column: "method_id",
                principalTable: "MethodsRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameter_id",
                table: "AnalysesRepository",
                column: "parameter_id",
                principalTable: "ParametersRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_type_id",
                table: "AnalysesRepository",
                column: "sample_type_id",
                principalTable: "SampleTypesRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_MethodsRepository_method_id",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_ParametersRepository_parameter_id",
                table: "AnalysesRepository");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesRepository_SampleTypesRepository_sample_type_id",
                table: "AnalysesRepository");

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_method_id",
                table: "AnalysesRepository");

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_parameter_id",
                table: "AnalysesRepository");

            migrationBuilder.DropIndex(
                name: "IX_AnalysesRepository_sample_type_id",
                table: "AnalysesRepository");

            migrationBuilder.AddColumn<Guid>(
                name: "methodId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parameterId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "sample_typeId",
                table: "AnalysesRepository",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_methodId",
                table: "AnalysesRepository",
                column: "methodId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_parameterId",
                table: "AnalysesRepository",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesRepository_sample_typeId",
                table: "AnalysesRepository",
                column: "sample_typeId");

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
    }
}
