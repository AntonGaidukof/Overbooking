using Microsoft.EntityFrameworkCore.Migrations;

namespace TLOverbookingInfrastructure.Migrations
{
    public partial class Update_Entities_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RoomStayFact",
                newName: "RoomStayFactId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProviderPredictionModel",
                newName: "ProviderPredictionModelId");

            migrationBuilder.RenameColumn(
                name: "BookingCancellationId",
                table: "BookingCancellation",
                newName: "BookingCancellationName");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ProviderPredictionModel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomStayFactId",
                table: "RoomStayFact",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderPredictionModelId",
                table: "ProviderPredictionModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingCancellationName",
                table: "BookingCancellation",
                newName: "BookingCancellationId");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ProviderPredictionModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
