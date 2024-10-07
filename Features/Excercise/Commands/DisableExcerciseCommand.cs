using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

namespace TrainPlanApi.Features.Excercise.Commands;

public class DisableExcerciseCommand : IRequest<BaseResponse<DisableExcerciseCommandResponse>>
{
    public int Id { get; set; }
}

public class DisableExcerciseCommandHandler : IRequestHandler<DisableExcerciseCommand, BaseResponse<DisableExcerciseCommandResponse>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<DisableExcerciseCommandHandler> _logger;
    private readonly IResponseService<DisableExcerciseCommandResponse> _response;
    private readonly IMapper _mapper;

    public DisableExcerciseCommandHandler(ApplicationDBContext dbContext, ILogger<DisableExcerciseCommandHandler> logger, IResponseService<DisableExcerciseCommandResponse> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }

    public async Task<BaseResponse<DisableExcerciseCommandResponse>> Handle(DisableExcerciseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var excercise = await _dbContext.Excercises.FirstOrDefaultAsync( e => e.Id == request.Id );
            
            if( excercise is null ) return _response.BadRequestResponse("Excercise does not exists.");
            
            excercise.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return _response.OkResponse( "Excercise has beeen modified.", new DisableExcerciseCommandResponse() { Id = excercise.Id } );
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}

public class DisableExcerciseCommandResponse
{
    public int Id { get; set; }
}