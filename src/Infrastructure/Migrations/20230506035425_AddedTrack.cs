using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c0ef2dbd-f704-47f4-bfd9-f698ff4af099"));

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ProjectId",
                table: "Tracks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("3a0dd590-5aef-48e9-9d29-94271db467eb"));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bpm", "Name", "TimeSig" },
                values: new object[] { new Guid("c0ef2dbd-f704-47f4-bfd9-f698ff4af099"), 155, "Drowning", "4/4" });
        }
    }
}
