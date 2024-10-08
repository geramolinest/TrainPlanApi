using System;

namespace TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class ExcerciseDetailCommandResponse
{  
    public int Id { get; set; }
    public decimal Weight { get; set; }
    public decimal Repetitions { get; set; }
    public decimal Rir { get; set; }
    public string Notes { get; set; }
    public int ExcerciseId { get; set; }
    public ExcerciseCommandResponse Excercise { get; set; }
    public int WorkoutId { get; set; }

}
