using System;

namespace TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class ExcerciseCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
