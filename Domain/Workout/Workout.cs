namespace TrainPlanApi.Domain.Workout;

using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Domain.WorkoutPlan;


public class Workout
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string WorkoutName { get; set; }
    public int WorkoutPlanId { get; set; }
    public WorkoutPlan WorkoutPlan { get; set; }
    public List<ExcerciseDetail> Excercises { get; set; }
}
