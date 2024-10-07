namespace TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Domain.Workout;

public class ExcerciseDetail
{
    public int Id { get; set; }
    public decimal Weight { get; set; }
    public decimal Repetitions { get; set; }
    public decimal Rir { get; set; }
    public string Notes { get; set; }
    public int ExcerciseId { get; set; }
    public Excercise Excercise { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
}
