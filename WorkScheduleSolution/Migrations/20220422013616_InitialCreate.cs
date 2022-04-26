using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkScheduleSolution.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    HomePhone = table.Column<string>(type: "CHAR(12)", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    Province = table.Column<string>(type: "NCHAR(2)", nullable: false),
                    Contract = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Phone = table.Column<string>(type: "CHAR(12)", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    RequiresTicket = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "PlacementContracts",
                columns: table => new
                {
                    PlacementContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementContracts", x => x.PlacementContractID);
                    table.ForeignKey(
                        name: "FK_PlacementContracts_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    HourlyWage = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.EmployeeSkillId);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacementContractID = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfEmployees = table.Column<byte>(type: "TINYINT", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_PlacementContracts_PlacementContractID",
                        column: x => x.PlacementContractID,
                        principalTable: "PlacementContracts",
                        principalColumn: "PlacementContractID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "DATE", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    HourlyWage = table.Column<decimal>(type: "MONEY", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedules_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeID",
                table: "EmployeeSkills",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillID",
                table: "EmployeeSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementContracts_LocationID",
                table: "PlacementContracts",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeID",
                table: "Schedules",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ShiftID",
                table: "Schedules",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_PlacementContractID",
                table: "Shifts",
                column: "PlacementContractID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "PlacementContracts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
