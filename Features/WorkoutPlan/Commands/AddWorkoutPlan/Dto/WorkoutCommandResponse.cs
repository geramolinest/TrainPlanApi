using System;

namespace TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class WorkoutCommandResponse
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string WorkoutName { get; set; }
    public int WorkoutPlanId { get; set; }
    public List<ExcerciseDetailCommandResponse> Excercises { get; set; }
}
