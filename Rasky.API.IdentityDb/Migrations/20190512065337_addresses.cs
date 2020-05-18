using Microsoft.EntityFrameworkCore.Migrations;

namespace Rasky.API.IdentityDb.Migrations
{
    public partial class addresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Address_FromAddressLongitude_FromAddressLatitude",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Address_ToAddressLongitude_ToAddressLatitude",
                table: "Rides");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Address_Latitude_Longitude",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Addresses_Latitude_Longitude",
                table: "Addresses",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                columns: new[] { "Longitude", "Latitude" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Addresses_FromAddressLongitude_FromAddressLatitude",
                table: "Rides",
                columns: new[] { "FromAddressLongitude", "FromAddressLatitude" },
                principalTable: "Addresses",
                principalColumns: new[] { "Longitude", "Latitude" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Addresses_ToAddressLongitude_ToAddressLatitude",
                table: "Rides",
                columns: new[] { "ToAddressLongitude", "ToAddressLatitude" },
                principalTable: "Addresses",
                principalColumns: new[] { "Longitude", "Latitude" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Addresses_FromAddressLongitude_FromAddressLatitude",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Addresses_ToAddressLongitude_ToAddressLatitude",
                table: "Rides");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Addresses_Latitude_Longitude",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Address_Latitude_Longitude",
                table: "Address",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                columns: new[] { "Longitude", "Latitude" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Address_FromAddressLongitude_FromAddressLatitude",
                table: "Rides",
                columns: new[] { "FromAddressLongitude", "FromAddressLatitude" },
                principalTable: "Address",
                principalColumns: new[] { "Longitude", "Latitude" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Address_ToAddressLongitude_ToAddressLatitude",
                table: "Rides",
                columns: new[] { "ToAddressLongitude", "ToAddressLatitude" },
                principalTable: "Address",
                principalColumns: new[] { "Longitude", "Latitude" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
