using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloodRescueManagementSystem.Repositories.Group5.Migrations
{
    /// <inheritdoc />
    public partial class First_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "relief_items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WarehouseLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relief_items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "System.UserAccount",
                columns: table => new
                {
                    UserAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RequestCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.UserAccount", x => x.UserAccountID);
                });

            migrationBuilder.CreateTable(
                name: "rescue_requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "MEDIUM"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "PENDING"),
                    VerifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rescue_requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_rescue_requests_System.UserAccount_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "System.UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rescue_requests_System.UserAccount_VerifierId",
                        column: x => x.VerifierId,
                        principalTable: "System.UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rescue_teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    CurrentLatitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    CurrentLongitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "READY"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rescue_teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_rescue_teams_System.UserAccount_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "System.UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "AVAILABLE"),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_vehicles_System.UserAccount_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "System.UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    AssignedBy = table.Column<int>(type: "int", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultReport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missions", x => x.MissionId);
                    table.ForeignKey(
                        name: "FK_missions_System.UserAccount_AssignedBy",
                        column: x => x.AssignedBy,
                        principalTable: "System.UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_missions_rescue_requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "rescue_requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_missions_rescue_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "rescue_teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_missions_vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "distribution_logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    QuantityDistributed = table.Column<int>(type: "int", nullable: false),
                    RecipientLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DistributedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distribution_logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_distribution_logs_missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_distribution_logs_relief_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "relief_items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_distribution_logs_ItemId",
                table: "distribution_logs",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_distribution_logs_MissionId",
                table: "distribution_logs",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_missions_AssignedBy",
                table: "missions",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_missions_RequestId",
                table: "missions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_missions_TeamId",
                table: "missions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_missions_VehicleId",
                table: "missions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_rescue_requests_CitizenId",
                table: "rescue_requests",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_rescue_requests_VerifierId",
                table: "rescue_requests",
                column: "VerifierId");

            migrationBuilder.CreateIndex(
                name: "IX_rescue_teams_LeaderId",
                table: "rescue_teams",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_ManagerId",
                table: "vehicles",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distribution_logs");

            migrationBuilder.DropTable(
                name: "missions");

            migrationBuilder.DropTable(
                name: "relief_items");

            migrationBuilder.DropTable(
                name: "rescue_requests");

            migrationBuilder.DropTable(
                name: "rescue_teams");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "System.UserAccount");
        }
    }
}
