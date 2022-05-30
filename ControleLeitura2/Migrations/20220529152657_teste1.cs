using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLeitura2.Migrations
{
    public partial class teste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivroCapaCaminho",
                table: "Livros",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivroCapaCaminho",
                table: "Livros");
        }
    }
}
