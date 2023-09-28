using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnDieuHoa.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_code",
                table: "product");

            migrationBuilder.DropColumn(
                name: "partner_id",
                table: "product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category_code",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "partner_id",
                table: "product",
                type: "bigint",
                nullable: true);
        }
    }
}
