using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnDieuHoa.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_warehouse_id",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "sale_price",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "product_total_cost",
                table: "order");

            migrationBuilder.DropColumn(
                name: "sale_cost",
                table: "order");

            migrationBuilder.DropColumn(
                name: "status",
                table: "order");

            migrationBuilder.DropColumn(
                name: "voucher_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "voucher_cost",
                table: "order",
                newName: "total_amount");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bank_account",
                table: "order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customer_adress",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "customer_name",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "customer_phone",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "transaction_code",
                table: "order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bank_account",
                table: "order");

            migrationBuilder.DropColumn(
                name: "customer_adress",
                table: "order");

            migrationBuilder.DropColumn(
                name: "customer_name",
                table: "order");

            migrationBuilder.DropColumn(
                name: "customer_phone",
                table: "order");

            migrationBuilder.DropColumn(
                name: "transaction_code",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "total_amount",
                table: "order",
                newName: "voucher_cost");

            migrationBuilder.AddColumn<long>(
                name: "product_warehouse_id",
                table: "order_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "sale_price",
                table: "order_detail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "warehouse_id",
                table: "order_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "customer_id",
                table: "order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "product_total_cost",
                table: "order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sale_cost",
                table: "order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "voucher_id",
                table: "order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "warehouse_id",
                table: "order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
