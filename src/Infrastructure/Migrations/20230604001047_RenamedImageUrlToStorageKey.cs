using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedImageUrlToStorageKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("9ab94514-a766-4af2-a0c4-54569f9c6df7"));

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("a26d920d-bdb6-435a-acc8-66904523f674"));

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("e04dc53e-e132-4db3-8924-f58256965f20"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb"));

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Tracks",
                newName: "StorageKey");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bpm", "Name", "TimeSig" },
                values: new object[] { new Guid("865a0144-ce5d-44dd-a3ab-8d01723037c9"), 155, "Drowning", "4/4" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Name", "ProjectId", "StorageKey" },
                values: new object[,]
                {
                    { new Guid("2a9c9a34-fc1e-4d78-98ad-fdf2c30b65a1"), "Guitar", new Guid("865a0144-ce5d-44dd-a3ab-8d01723037c9"), null },
                    { new Guid("7daa3c30-e3e0-4bf3-919b-cd78ff353e94"), "Vocals", new Guid("865a0144-ce5d-44dd-a3ab-8d01723037c9"), null },
                    { new Guid("96998219-aa89-4ae4-96e3-4e532e4f636e"), "Drums", new Guid("865a0144-ce5d-44dd-a3ab-8d01723037c9"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("2a9c9a34-fc1e-4d78-98ad-fdf2c30b65a1"));

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("7daa3c30-e3e0-4bf3-919b-cd78ff353e94"));

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: new Guid("96998219-aa89-4ae4-96e3-4e532e4f636e"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("865a0144-ce5d-44dd-a3ab-8d01723037c9"));

            migrationBuilder.RenameColumn(
                name: "StorageKey",
                table: "Tracks",
                newName: "ImageUrl");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bpm", "Name", "TimeSig" },
                values: new object[] { new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb"), 155, "Drowning", "4/4" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "ImageUrl", "Name", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("9ab94514-a766-4af2-a0c4-54569f9c6df7"), null, "Vocals", new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb") },
                    { new Guid("a26d920d-bdb6-435a-acc8-66904523f674"), null, "Drums", new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb") },
                    { new Guid("e04dc53e-e132-4db3-8924-f58256965f20"), null, "Guitar", new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb") }
                });
        }
    }
}
