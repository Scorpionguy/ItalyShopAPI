using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItalyShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class prefinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_client_id_client_fk",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_order_order_id_fk",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropColumn(
                name: "g_quantity",
                table: "goods");

            migrationBuilder.DropColumn(
                name: "is_new",
                table: "goods");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_order_id_client_fk",
                table: "orders",
                newName: "IX_orders_id_client_fk");

            migrationBuilder.AddColumn<string>(
                name: "characteristics",
                table: "goods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "goods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id_order");

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    id_size = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_s = table.Column<string>(type: "text", nullable: false),
                    quantity_s = table.Column<int>(type: "integer", nullable: false),
                    good_fk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.id_size);
                    table.ForeignKey(
                        name: "FK_sizes_goods_good_fk",
                        column: x => x.good_fk,
                        principalTable: "goods",
                        principalColumn: "article",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sizes_good_fk",
                table: "sizes",
                column: "good_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_orders_order_id_fk",
                table: "order_items",
                column: "order_id_fk",
                principalTable: "orders",
                principalColumn: "id_order",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_client_id_client_fk",
                table: "orders",
                column: "id_client_fk",
                principalTable: "client",
                principalColumn: "id_client",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_orders_order_id_fk",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_client_id_client_fk",
                table: "orders");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "characteristics",
                table: "goods");

            migrationBuilder.DropColumn(
                name: "description",
                table: "goods");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_id_client_fk",
                table: "order",
                newName: "IX_order_id_client_fk");

            migrationBuilder.AddColumn<int>(
                name: "g_quantity",
                table: "goods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_new",
                table: "goods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "id_order");

            migrationBuilder.AddForeignKey(
                name: "FK_order_client_id_client_fk",
                table: "order",
                column: "id_client_fk",
                principalTable: "client",
                principalColumn: "id_client",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_order_order_id_fk",
                table: "order_items",
                column: "order_id_fk",
                principalTable: "order",
                principalColumn: "id_order",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
