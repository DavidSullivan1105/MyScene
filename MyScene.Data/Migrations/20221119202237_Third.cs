using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyScene.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyScenes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyScenes", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MySceneArtist",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    MyArtistsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySceneArtist", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_MySceneArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MySceneArtist_MyScenes_MyArtistsUserId",
                        column: x => x.MyArtistsUserId,
                        principalTable: "MyScenes",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MySceneBand",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    MyBandsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySceneBand", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_MySceneBand_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MySceneBand_MyScenes_MyBandsUserId",
                        column: x => x.MyBandsUserId,
                        principalTable: "MyScenes",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MySceneVenue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    MyVenueUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySceneVenue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MySceneVenue_MyScenes_MyVenueUserId",
                        column: x => x.MyVenueUserId,
                        principalTable: "MyScenes",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MySceneVenue_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MySceneArtist_ArtistId",
                table: "MySceneArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MySceneArtist_MyArtistsUserId",
                table: "MySceneArtist",
                column: "MyArtistsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySceneBand_BandId",
                table: "MySceneBand",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_MySceneBand_MyBandsUserId",
                table: "MySceneBand",
                column: "MyBandsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySceneVenue_MyVenueUserId",
                table: "MySceneVenue",
                column: "MyVenueUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySceneVenue_VenueId",
                table: "MySceneVenue",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MySceneArtist");

            migrationBuilder.DropTable(
                name: "MySceneBand");

            migrationBuilder.DropTable(
                name: "MySceneVenue");

            migrationBuilder.DropTable(
                name: "MyScenes");
        }
    }
}
