using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItalyShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class zero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id_client = table.Column<string>(type: "text", nullable: false),
                    c_name = table.Column<string>(type: "text", nullable: false),
                    c_family = table.Column<string>(type: "text", nullable: false),
                    c_otchestvo = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<string>(type: "text", nullable: true),
                    adress = table.Column<string>(type: "text", nullable: true),
                    c_phone = table.Column<string>(type: "text", nullable: true),
                    c_mail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "title",
                columns: table => new
                {
                    id_title = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title", x => x.id_title);
                });

            migrationBuilder.CreateTable(
                name: "goods",
                columns: table => new
                {
                    article = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    g_name = table.Column<string>(type: "text", nullable: false),
                    category_fk = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    g_quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    sale = table.Column<int>(type: "integer", nullable: true),
                    add_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    is_new = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods", x => x.article);
                    table.ForeignKey(
                        name: "FK_goods_category_category_fk",
                        column: x => x.category_fk,
                        principalTable: "category",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id_order = table.Column<string>(type: "text", nullable: false),
                    id_client_fk = table.Column<string>(type: "text", nullable: false),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_status = table.Column<string>(type: "text", nullable: false),
                    total_amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id_order);
                    table.ForeignKey(
                        name: "FK_order_client_id_client_fk",
                        column: x => x.id_client_fk,
                        principalTable: "client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id_empl = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    e_family = table.Column<string>(type: "text", nullable: false),
                    e_name = table.Column<string>(type: "text", nullable: false),
                    e_otchestvo = table.Column<string>(type: "text", nullable: true),
                    job_title_fk = table.Column<int>(type: "integer", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id_empl);
                    table.ForeignKey(
                        name: "FK_employee_title_job_title_fk",
                        column: x => x.job_title_fk,
                        principalTable: "title",
                        principalColumn: "id_title",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id_items = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id_fk = table.Column<string>(type: "text", nullable: false),
                    article_fk = table.Column<int>(type: "integer", nullable: false),
                    o_quantity = table.Column<int>(type: "integer", nullable: false),
                    price_at_purchase = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.id_items);
                    table.ForeignKey(
                        name: "FK_order_items_goods_article_fk",
                        column: x => x.article_fk,
                        principalTable: "goods",
                        principalColumn: "article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_order_order_id_fk",
                        column: x => x.order_id_fk,
                        principalTable: "order",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    id_log = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_emp_fk = table.Column<int>(type: "integer", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    log_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    log_time = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.id_log);
                    table.ForeignKey(
                        name: "FK_log_employee_id_emp_fk",
                        column: x => x.id_emp_fk,
                        principalTable: "employee",
                        principalColumn: "id_empl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_job_title_fk",
                table: "employee",
                column: "job_title_fk");

            migrationBuilder.CreateIndex(
                name: "IX_goods_category_fk",
                table: "goods",
                column: "category_fk");

            migrationBuilder.CreateIndex(
                name: "IX_log_id_emp_fk",
                table: "log",
                column: "id_emp_fk");

            migrationBuilder.CreateIndex(
                name: "IX_order_id_client_fk",
                table: "order",
                column: "id_client_fk");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_article_fk",
                table: "order_items",
                column: "article_fk");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id_fk",
                table: "order_items",
                column: "order_id_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "title");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
