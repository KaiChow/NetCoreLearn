using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTourist.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CraeteTime", "DepatrureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("63541d8f-840d-490e-b3c6-def1093eceee"), new DateTime(2021, 5, 2, 3, 23, 59, 190, DateTimeKind.Utc).AddTicks(7002), null, "测试说明", null, null, null, null, 1299m, "测试数据Title", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("63541d8f-840d-490e-b3c6-def1093eceee"));
        }
    }
}
