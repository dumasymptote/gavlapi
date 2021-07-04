using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace gavl_api.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MailingPostal",
                table: "Accounts",
                newName: "MailingPostalCode");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SSNFEIN = table.Column<int>(type: "integer", nullable: false),
                    MailingAddress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MailingAddressLine2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MailingCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MailingState = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    MailingPostalCode = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    PhysicalAddress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PhysicalAddressLine2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PhysicalCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PhysicalState = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    PhysicalPostalCode = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber1 = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IntakeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EngagmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClient",
                columns: table => new
                {
                    AssignedUsersId = table.Column<string>(type: "text", nullable: false),
                    ClientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClient", x => new { x.AssignedUsersId, x.ClientsId });
                    table.ForeignKey(
                        name: "FK_AppUserClient_AspNetUsers_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserClient_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AccountId", "Active", "DateOfBirth", "Email", "EngagmentDate", "FirstName", "IntakeDate", "LastName", "MailingAddress", "MailingAddressLine2", "MailingCity", "MailingPostalCode", "MailingState", "OrganizationName", "PhoneNumber1", "PhoneNumber2", "PhysicalAddress", "PhysicalAddressLine2", "PhysicalCity", "PhysicalPostalCode", "PhysicalState", "SSNFEIN" },
                values: new object[] { 1, null, true, new DateTime(1991, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), "Test@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client", "123 Test", "Suite 1", "Testville", "76553", "TX", "Clients Against Testing", "2142129004", "", "123 Test", "Suite 1", "Testville", "76553", "TX", 111111111 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClient_ClientsId",
                table: "AppUserClient",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountId",
                table: "Clients",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserClient");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.RenameColumn(
                name: "MailingPostalCode",
                table: "Accounts",
                newName: "MailingPostal");
        }
    }
}
