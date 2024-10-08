using System;

namespace TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class WorkoutInput
{
    public DateOnly Date { get; set; }
    public string WorkoutName { get; set; }
    public IEnumerable<ExcerciseDetailInput> Excercises { get; set; }
}
