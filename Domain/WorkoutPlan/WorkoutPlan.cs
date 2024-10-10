namespace TrainPlanApi.Domain.WorkoutPlan;

using Microsoft.AspNetCore.Identity;
using TrainPlanApi.Domain.Workout;

public class WorkoutPlan
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<Workout> Workouts { get; set; }
    public IdentityUser IdentityUser { get; set; }
     public int? WorkoutPlanTypeId { get; set; }
     public WorkoutPlanType WorkoutPlanType { get; set; }
}
