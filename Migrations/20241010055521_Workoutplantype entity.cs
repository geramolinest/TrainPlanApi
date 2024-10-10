using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrainPlanApi.Migrations
{
    /// <inheritdoc />
    public partial class Workoutplantypeentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutPlanTypeId",
                table: "WorkoutPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutPlanType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    DurationInDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_WorkoutPlanTypeId",
                table: "WorkoutPlans",
                column: "WorkoutPlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_WorkoutPlanType_WorkoutPlanTypeId",
                table: "WorkoutPlans",
                column: "WorkoutPlanTypeId",
                principalTable: "WorkoutPlanType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_WorkoutPlanType_WorkoutPlanTypeId",
                table: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "WorkoutPlanType");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_WorkoutPlanTypeId",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "WorkoutPlanTypeId",
                table: "WorkoutPlans");
        }
    }
}
