namespace TrainPlanApi.Features.WorkoutPlan.Commands;

using TrainPlanApi.Domain.WorkoutPlan;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Features.WorkoutPlan.Commands.AddWorkoutPlan.Dto;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;
using TrainPlanApi.Domain.Workout;
using TrainPlanApi.Domain.Excercise;

public class AddWorkoutPlanCommand : IRequest<BaseResponse<AddExcerciseWorkoutPlanCommandResponse>>
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public IEnumerable<WorkoutInput> Workouts { get; set; }
    public string UserId { get; set; }
    
}

public class AddWorkoutPlanCommandHandler : IRequestHandler<AddWorkoutPlanCommand, BaseResponse<AddExcerciseWorkoutPlanCommandResponse>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<AddWorkoutPlanCommandHandler> _logger;
    private readonly IResponseService<AddExcerciseWorkoutPlanCommandResponse> _response;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    public AddWorkoutPlanCommandHandler(ApplicationDBContext dbContext, UserManager<IdentityUser> userManager,ILogger<AddWorkoutPlanCommandHandler> logger, IResponseService<AddExcerciseWorkoutPlanCommandResponse> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<BaseResponse<AddExcerciseWorkoutPlanCommandResponse>> Handle(AddWorkoutPlanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userManager.FindByIdAsync( request.UserId );

            if( user is null ) return _response.BadRequestResponse("User does not exists");

            var workoutPlan = _mapper.Map<WorkoutPlan>( request );

            workoutPlan.IdentityUser = user;

            foreach(var workout in workoutPlan.Workouts)
            {
                foreach(var excerciseDetail in workout.Excercises)
                {
                    var exists = await _dbContext.Excercises.AnyAsync( e => e.Id == excerciseDetail.ExcerciseId );

                    if( !exists ) return _response.BadRequestResponse($"Excercise with id { excerciseDetail.ExcerciseId  }  does not exists.");
                    
                    excerciseDetail.Workout = workout;
                }
            }

            await _dbContext.AddAsync( workoutPlan );

            await _dbContext.SaveChangesAsync();

            var responseMapped = _mapper.Map<AddExcerciseWorkoutPlanCommandResponse>( workoutPlan );

            return _response.OkResponse("Workout Plan saved successfully.", responseMapped);
        }
        catch (Exception e)
        {
            _logger.LogError( e, e.Message );
            return _response.InternalServerErrorResponse();
        }
    }
}

public class AddExcerciseWorkoutPlanCommandResponse
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<WorkoutCommandResponse> Workouts { get; set; }
    public IdentityUserResponse IdentityUser { get; set; }
}
