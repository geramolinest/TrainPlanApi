namespace TrainPlanApi.Profiles.WorkoutPlan;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Domain.Workout;
using TrainPlanApi.Domain.WorkoutPlan;
using TrainPlanApi.Features.WorkoutPlan.Commands;
using TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;

public class WorkoutPlanProfile : Profile
{
    public WorkoutPlanProfile()
    {
        CreateMap<AddWorkoutPlanCommand, WorkoutPlan>();

        CreateMap<WorkoutInput, Workout>();

        CreateMap<ExcerciseDetailInput, ExcerciseDetail>();

        CreateMap<Workout, WorkoutCommandResponse>();
        CreateMap<ExcerciseDetail, ExcerciseDetailCommandResponse>();
        CreateMap<WorkoutPlan, AddExcerciseWorkoutPlanCommandResponse>();
        CreateMap<IdentityUser, IdentityUserResponse>();
    }
}
