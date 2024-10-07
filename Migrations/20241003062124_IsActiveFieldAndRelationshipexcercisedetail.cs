using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainPlanApi.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveFieldAndRelationshipexcercisedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excercises_Workouts_WorkoutId",
                table: "Excercises");

            migrationBuilder.DropIndex(
                name: "IX_Excercises_WorkoutId",
                table: "Excercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Excercises");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Excercises",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Excercises");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Excercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Excercises_WorkoutId",
                table: "Excercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excercises_Workouts_WorkoutId",
                table: "Excercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }
    }
}
