using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Services.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractState = table.Column<int>(type: "int", nullable: false),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResubmissionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPdf = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowDocument",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    WorkflowId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DocumentRefId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    WorkflowDefinitionId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTaskHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TaskId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTaskHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTaskHistory_WorkflowDocument_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "WorkflowDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Contract" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTaskHistory_DocumentId",
                table: "DocumentTaskHistory",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDocument_DocumentRefId_DocumentType_WorkflowDefinitionId_Version",
                table: "WorkflowDocument",
                columns: new[] { "DocumentRefId", "DocumentType", "WorkflowDefinitionId", "Version" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "DocumentTaskHistory");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "WorkflowDocument");
        }
    }
}
