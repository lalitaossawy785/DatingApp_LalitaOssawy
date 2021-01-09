using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) //What to do going up
        {
            migrationBuilder.CreateTable( //Create table called users
                name: "Users",
                columns: table => new //Two columns, Id & Usernames
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false) //Knows it is a primary key
                        .Annotation("Sqlite:Autoincrement", true), //Autoincrement everytime a new record is created
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) //Removing a migration
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
