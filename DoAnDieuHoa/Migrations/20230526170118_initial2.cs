using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnDieuHoa.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avata",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avata",
                table: "product");
        }
    }
}
