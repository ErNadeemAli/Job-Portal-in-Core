using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_portal_in_Core.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    CompanyID = table.Column<int>(name: "Company ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(name: "Company Name", type: "nvarchar(max)", nullable: false),
                    CompanyURL = table.Column<string>(name: "Company URL", type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(name: "Company Email", type: "nvarchar(max)", nullable: false),
                    CompanyPassword = table.Column<string>(name: "Company Password", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiter", x => x.CompanyID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruiter");
        }
    }
}
