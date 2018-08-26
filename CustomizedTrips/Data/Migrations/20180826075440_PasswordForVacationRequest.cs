using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomizedTrips.Data.Migrations
{
    public partial class PasswordForVacationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "VacationRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "VacationRequest");
        }
    }
}
