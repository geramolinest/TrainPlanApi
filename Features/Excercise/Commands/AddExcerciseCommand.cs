namespace TrainPlanApi.Features.Excercise.Commands;

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

public class AddExcerciseCommand : IRequest<BaseResponse<AddExcerciseCommandResponse>>
{
    [Required]
    public string Name { get; set; }
}

public class AddExcerciseCommandHandler : IRequestHandler<AddExcerciseCommand, BaseResponse<AddExcerciseCommandResponse>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<AddExcerciseCommandHandler> _logger;
    private readonly IResponseService<AddExcerciseCommandResponse> _response;
    private readonly IMapper _mapper;

    public AddExcerciseCommandHandler(ApplicationDBContext dbContext, ILogger<AddExcerciseCommandHandler> logger, IResponseService<AddExcerciseCommandResponse> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }
    public async Task<BaseResponse<AddExcerciseCommandResponse>> Handle(AddExcerciseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var exists = await _dbContext.Excercises.AnyAsync( e => e.Name.Trim().ToUpper().Equals(request.Name.Trim().ToUpper()) );
            
            if( exists ) return _response.BadRequestResponse("Excercise already exists, please check your excercise catalog.");
            
            _logger.LogInformation("Excercise does not exists, saving the new one.");

            var excerciseMapped = _mapper.Map<Excercise>( request );

            excerciseMapped.IsActive = true;

            await _dbContext.AddAsync( excerciseMapped );

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Excercise saved, returning result.");

            var excerciseResponse = _mapper.Map<AddExcerciseCommandResponse>( excerciseMapped );

            return _response.CreatedResponse( "Excercise has beeen added", excerciseResponse );
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}

public class AddExcerciseCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
