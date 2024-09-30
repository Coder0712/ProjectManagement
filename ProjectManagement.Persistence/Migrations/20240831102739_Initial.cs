using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KanbanBoard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectKanbanBoardReference",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    KanbanBoardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectKanbanBoardReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectKanbanBoardReference_KanbanBoard_KanbanBoardId",
                        column: x => x.KanbanBoardId,
                        principalTable: "KanbanBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectKanbanBoardReference_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectKanbanBoardReference_KanbanBoardId",
                table: "ProjectKanbanBoardReference",
                column: "KanbanBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectKanbanBoardReference_ProjectId",
                table: "ProjectKanbanBoardReference",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectKanbanBoardReference");

            migrationBuilder.DropTable(
                name: "KanbanBoard");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
