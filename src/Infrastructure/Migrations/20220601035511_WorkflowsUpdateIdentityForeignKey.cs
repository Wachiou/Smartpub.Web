using Microsoft.EntityFrameworkCore.Migrations;

namespace MVWorkflows.Infrastructure.Migrations
{
    public partial class WorkflowsUpdateIdentityForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstance_Workflows_WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowInstance_WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance");

            migrationBuilder.DropColumn(
                name: "WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowsId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstance_Workflows_WorkflowsId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowsId",
                principalSchema: "Workflows",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowInstance_Workflows_WorkflowsId",
                schema: "Workflows",
                table: "WorkflowInstance");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowInstance_WorkflowsId",
                schema: "Workflows",
                table: "WorkflowInstance");

            migrationBuilder.AddColumn<int>(
                name: "WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowInstance_Workflows_WorkflowId",
                schema: "Workflows",
                table: "WorkflowInstance",
                column: "WorkflowId",
                principalSchema: "Workflows",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
