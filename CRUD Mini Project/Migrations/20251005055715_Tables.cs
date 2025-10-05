using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Mini_Project.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MethodsRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodsRepository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametersRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersRepository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleTypesRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTypesRepository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalysesRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parameter_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    method_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sample_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    methodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sample_typeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysesRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysesRepository_MethodsRepository_methodId",
                        column: x => x.methodId,
                        principalTable: "MethodsRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysesRepository_ParametersRepository_parameterId",
                        column: x => x.parameterId,
                        principalTable: "ParametersRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysesRepository_SampleTypesRepository_sample_typeId",
                        column: x => x.sample_typeId,
                        principalTable: "SampleTypesRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysesRepository");

            migrationBuilder.DropTable(
                name: "MethodsRepository");

            migrationBuilder.DropTable(
                name: "ParametersRepository");

            migrationBuilder.DropTable(
                name: "SampleTypesRepository");
        }
    }
}
