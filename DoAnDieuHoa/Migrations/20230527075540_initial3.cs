using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnDieuHoa.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "admin_user");

            migrationBuilder.DropColumn(
                name: "district_id",
                table: "admin_user");

            migrationBuilder.DropColumn(
                name: "province_id",
                table: "admin_user");

            migrationBuilder.DropColumn(
                name: "type",
                table: "admin_user");

            migrationBuilder.DropColumn(
                name: "ward_id",
                table: "admin_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "admin_user",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "district_id",
                table: "admin_user",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "province_id",
                table: "admin_user",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "type",
                table: "admin_user",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "ward_id",
                table: "admin_user",
                type: "bigint",
                nullable: true);
        }
    }
}
