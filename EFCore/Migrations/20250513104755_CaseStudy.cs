using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CaseStudy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Ssn = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Fname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Minit = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Lname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Bdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Sex = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Salary = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Super_ssn = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    Dno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Ssn);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_Super_ssn",
                        column: x => x.Super_ssn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Mgr_ssn = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    Mgr_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnumber);
                    table.ForeignKey(
                        name: "FK_Departments_Employees_Mgr_ssn",
                        column: x => x.Mgr_ssn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Essn = table.Column<string>(type: "character varying(9)", nullable: false),
                    Dependent_name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    Bdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Essn, x.Dependent_name });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_Essn",
                        column: x => x.Essn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeptLocations",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "integer", nullable: false),
                    Dlocation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptLocations", x => new { x.Dnumber, x.Dlocation });
                    table.ForeignKey(
                        name: "FK_DeptLocations_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeptLocations_Locations_Dlocation",
                        column: x => x.Dlocation,
                        principalTable: "Locations",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Plocation = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Dnum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    Essn = table.Column<string>(type: "character varying(9)", nullable: false),
                    Pno = table.Column<int>(type: "integer", nullable: false),
                    Hours = table.Column<decimal>(type: "numeric(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.Essn, x.Pno });
                    table.ForeignKey(
                        name: "FK_WorksOn_Employees_Essn",
                        column: x => x.Essn,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Projects_Pno",
                        column: x => x.Pno,
                        principalTable: "Projects",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Mgr_ssn",
                table: "Departments",
                column: "Mgr_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_DeptLocations_Dlocation",
                table: "DeptLocations",
                column: "Dlocation");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Super_ssn",
                table: "Employees",
                column: "Super_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dnum",
                table: "Projects",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_Pno",
                table: "WorksOn",
                column: "Pno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "DeptLocations");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });
        }
    }
}
