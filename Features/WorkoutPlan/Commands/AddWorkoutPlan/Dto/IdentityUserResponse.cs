using System;

namespace TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class IdentityUserResponse
{
    public string Id { get; set; }
    public string NormalizedUserName { get; set; }
}
