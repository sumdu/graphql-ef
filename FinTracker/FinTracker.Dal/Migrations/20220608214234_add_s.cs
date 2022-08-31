using FinTracker.Dal.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTracker.Dal.Migrations
{
    public partial class add_s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("FinTracker.Dal.SqlChanges.GetTransactions.v1.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("FinTracker.Dal.SqlChanges.GetTransactions.v0.sql");
        }
    }
}
