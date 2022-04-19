using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLOverbookingInfrastructure.Migrations
{
    public partial class Add_RoomStayCancellationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomStayCancellationModel",
                columns: table => new
                {
                    RoomStayCancellationModelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLearningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStayCancellationModel", x => x.RoomStayCancellationModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomStayCancellationModel");
        }
    }
}
