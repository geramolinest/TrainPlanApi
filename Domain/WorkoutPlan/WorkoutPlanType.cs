using System;

namespace TrainPlanApi.Domain.WorkoutPlan;

public class WorkoutPlanType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal DurationInDays { get; set; }
}
