using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_helper_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Existing database tables are already created.
            // This migration establishes the initial EF Core baseline.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Intentionally empty.
            // Do not drop the pre-existing database tables.
        }
    }
}
