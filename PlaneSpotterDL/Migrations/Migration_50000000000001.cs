using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("Migration_50000000000001")]
    public class Migration_50000000000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "AircraftSpotters",
             columns: table => new
             {
                 RecordId = table.Column<int>(type: "uniqueidentifier", nullable: false),
                 Make = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                 Model = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                 Registration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                 SpottedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                 FilePath = table.Column<DateTime>(type: "nvarchar(max)", nullable: false, defaultValue: "")
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_AircraftSpotters", x => x.RecordId);
             });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                 name: "AircraftSpotters");
        }
    }
}
