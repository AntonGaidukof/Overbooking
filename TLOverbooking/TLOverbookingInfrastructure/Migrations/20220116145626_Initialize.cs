using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLOverbookingInfrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderPredictionModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderPredictionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomStayFact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    DuratuionInDays = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdultsAmount = table.Column<int>(type: "int", nullable: false),
                    ChildrenAmount = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    RatePlanId = table.Column<long>(type: "bigint", nullable: false),
                    ProviderId = table.Column<long>(type: "bigint", nullable: false),
                    DaysBetweenCheckInAndCanceling = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStayFact", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderPredictionModel");

            migrationBuilder.DropTable(
                name: "RoomStayFact");
        }
    }
}
