namespace TrainPlanApi.Features.Excercise.Queries;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

public class GetExcerciseByIdQuery : IRequest<BaseResponse<GetExcerciseByIdQueryResponse>>
{
    public int Id { get; set; }
}

public class GetExcerciseByIdQueryHandler : IRequestHandler<GetExcerciseByIdQuery, BaseResponse<GetExcerciseByIdQueryResponse>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetExcerciseByIdQueryHandler> _logger;
    private readonly IResponseService<GetExcerciseByIdQueryResponse> _response;
    private readonly IMapper _mapper;

    public GetExcerciseByIdQueryHandler(ApplicationDBContext dbContext, ILogger<GetExcerciseByIdQueryHandler> logger, IResponseService<GetExcerciseByIdQueryResponse> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }
    public async Task<BaseResponse<GetExcerciseByIdQueryResponse>> Handle(GetExcerciseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var excercise = await _dbContext.Excercises.ProjectTo<GetExcerciseByIdQueryResponse>(_mapper.ConfigurationProvider).FirstOrDefaultAsync( e => e.Id == request.Id );

            if(excercise is null) return _response.NotFoundResponse("Excercise does not exists");

            _logger.LogInformation("Excercise exists, returning result");

            return _response.OkResponse( data: excercise );
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}


public class GetExcerciseByIdQueryResponse 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}