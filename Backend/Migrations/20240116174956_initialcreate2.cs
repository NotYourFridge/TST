﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingScript.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackingData",
                columns: table => new
                {
                    TrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    HoverCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingData", x => x.TrackingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingData");
        }
    }
}
