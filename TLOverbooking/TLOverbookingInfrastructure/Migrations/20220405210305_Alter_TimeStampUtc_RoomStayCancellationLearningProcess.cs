using Microsoft.EntityFrameworkCore.Migrations;

namespace TLOverbookingInfrastructure.Migrations
{
    public partial class Alter_TimeStampUtc_RoomStayCancellationLearningProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "RoomStayCancellationLearningProcess",
                newName: "TimeStampUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStampUtc",
                table: "RoomStayCancellationLearningProcess",
                newName: "TimeStamp");
        }
    }
}
