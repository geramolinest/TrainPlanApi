using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainPlanApi.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_IdentityUserId1",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_IdentityUserId1",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "WorkoutPlans");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "WorkoutPlans",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_IdentityUserId",
                table: "WorkoutPlans",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_IdentityUserId",
                table: "WorkoutPlans",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_IdentityUserId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_IdentityUserId",
                table: "WorkoutPlans");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "WorkoutPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "WorkoutPlans",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_IdentityUserId1",
                table: "WorkoutPlans",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_IdentityUserId1",
                table: "WorkoutPlans",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
