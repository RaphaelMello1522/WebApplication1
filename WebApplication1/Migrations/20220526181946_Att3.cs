using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Att3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "vencimento",
                table: "FileModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fornecedor",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "valor",
                table: "FileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "vencimento",
                table: "FileModels",
                type: "datetime2",
                nullable: true);
        }
    }
}
