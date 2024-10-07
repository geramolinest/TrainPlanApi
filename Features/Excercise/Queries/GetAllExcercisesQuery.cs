using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

namespace TrainPlanApi.Features.Excercise.Queries;

public class GetAllExcercisesQuery : IRequest<BaseResponse<List<GetAllExcercisesQueryResponse>>>
{

}

public class GetAllExcercisesQueryHandler : IRequestHandler<GetAllExcercisesQuery, BaseResponse<List<GetAllExcercisesQueryResponse>>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetAllExcercisesQueryHandler> _logger;
    private readonly IResponseService<List<GetAllExcercisesQueryResponse>> _response;
    private readonly IMapper _mapper;

    public GetAllExcercisesQueryHandler(ApplicationDBContext dbContext, ILogger<GetAllExcercisesQueryHandler> logger, IResponseService<List<GetAllExcercisesQueryResponse>> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }
    public async Task<BaseResponse<List<GetAllExcercisesQueryResponse>>> Handle(GetAllExcercisesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var excercises = await _dbContext.Excercises
                                    .ProjectTo<GetAllExcercisesQueryResponse>(_mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

            _logger.LogInformation("Returning excercises result.");

            return _response.OkResponse( data: excercises);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}

public class GetAllExcercisesQueryResponse 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}