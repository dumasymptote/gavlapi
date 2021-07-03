using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace gavl_api.Migrations
{
    public partial class AddAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MailingAddress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MailingCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MailingState = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    MailingPostal = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    LicensedUsers = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "10")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "LicensedUsers", "MailingAddress", "MailingCity", "MailingPostal", "MailingState", "Name" },
                values: new object[] { 1, 11, "123 Main St", "Cityopolis", "DC", null, "TestAccount1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
