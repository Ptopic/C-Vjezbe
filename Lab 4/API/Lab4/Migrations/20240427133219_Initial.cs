using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab4.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientOib = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PatientMbo = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DiagnosisId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfAdmittance = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfDischarge = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PatientGender = table.Column<int>(type: "integer", nullable: false),
                    PatientInsurance = table.Column<int>(type: "integer", nullable: false),
                    IsDischarged = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("2f5541d0-e32e-4d85-a5ae-37ca9baf7d24"), "Neoplazme", "C00-D48" },
                    { new Guid("576fd12d-6eda-44ae-8445-9bd7f5804981"), "Endokrine, nutricijske i metaboličke bolesti", "E00-E90" },
                    { new Guid("84aff43b-017c-421e-846b-9b55ba1dc61d"), "Mentalni poremećaji i poremećaji ponašanja", "F00-F99" },
                    { new Guid("8a3bc909-ffda-47af-8817-2ee9d80baee2"), "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava", "C50-D89" },
                    { new Guid("8abf961e-67e5-4c66-82cd-804e521f7e68"), "Bolesti oka i adneksa", "H00-H59" },
                    { new Guid("c4164c91-408f-4f2c-9963-0f17f915fb32"), "Bolesti živčanog sustava", "G00-G99" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfAdmittance", "DateOfBirth", "DateOfDischarge", "DiagnosisId", "FirstName", "IsDischarged", "LastName", "PatientGender", "PatientInsurance", "PatientMbo", "PatientOib" },
                values: new object[,]
                {
                    { new Guid("cc066571-162b-4c8b-b912-9394e7639c43"), new DateTime(2024, 4, 14, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(1999, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 18, 22, 0, 0, 0, DateTimeKind.Utc), new Guid("84aff43b-017c-421e-846b-9b55ba1dc61d"), "Ivo", true, "Ivic", 0, 0, "222222222", "22222222222" },
                    { new Guid("cc3835ad-5937-4426-b8e3-8a1d0a27a495"), new DateTime(2024, 4, 19, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2002, 10, 14, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 24, 22, 0, 0, 0, DateTimeKind.Utc), new Guid("8abf961e-67e5-4c66-82cd-804e521f7e68"), "Petar", true, "Topić", 0, 1, "111111111", "11111111111" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiagnosisId",
                table: "Patients",
                column: "DiagnosisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Diagnoses");
        }
    }
}
