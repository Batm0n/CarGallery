using Microsoft.EntityFrameworkCore.Migrations;

namespace CarGallery.Migrations
{
    public partial class SetupDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnaiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Porsche" });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "Ferrari" });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, null, "Ford" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "ImageUrl", "LongDescription", "Name", "ShortDescription", "ThumbnaiUrl", "ThumbnailUrl" },
                values: new object[] { 1, 1, "/assets/porsche/porsche_911_Turbo.jpg", "Sempre que um carro apresenta um comportamento irrepreensível, é difícil não nos perguntarmos como será possível fazer algo melhor em uma futura geração. Desde a primeira edição do 911 Turbo, em 1975, porém, os engenheiros da Porsche vêm conseguindo essa insuspeita superação e desta vez não foi diferente.", "Porsche 911 Turbo", "Porsche 911 Turbo S", null, "/assets/porsche/porsche_911_Turbo_small.jpg" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "ImageUrl", "LongDescription", "Name", "ShortDescription", "ThumbnaiUrl", "ThumbnailUrl" },
                values: new object[] { 2, 3, "/assets/ford/ford_mustang.jpg", "O Mustang GT é absolutamente a melhor forma de começar o dia, já que seu motor é uma joia. O V8 ainda mantém o nome de Coyote, mas não é quieto como o anterior. O motor esbraveja como o melhor muscle car de todos os tempos.", "Ford Mustang", "O melhor pony car", null, "/assets/ford/ford_mustang_small.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
