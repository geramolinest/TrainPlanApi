using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Domain.Workout;
using TrainPlanApi.Domain.WorkoutPlan;

namespace TrainPlanApi.Infrastructure.Persistence;

public class ApplicationDBContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options ) : base(options)
    {
        
    }
    
    public DbSet<Excercise> Excercises { get; set; }
    public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<ExcerciseDetail> ExcerciseDetails { get; set; }
}
