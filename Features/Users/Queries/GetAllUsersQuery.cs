using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

namespace TrainPlanApi.Features.Users.Queries;

public class GetAllUsersQuery : IRequest<BaseResponse<List<GetAllUsersQueryResponse>>>
{

}


public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, BaseResponse<List<GetAllUsersQueryResponse>>>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<GetAllUsersQueryHandler> _logger;
    private readonly IResponseService<List<GetAllUsersQueryResponse>> _response;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(UserManager<IdentityUser> userManager, ILogger<GetAllUsersQueryHandler> logger, IResponseService<List<GetAllUsersQueryResponse>> response, IMapper mapper)
    {
        _userManager = userManager;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var usersResult = await _userManager
                                    .Users
                                    .ProjectTo<GetAllUsersQueryResponse>(_mapper.ConfigurationProvider)
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);

            return _response.OkResponse(data: usersResult);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}

public class GetAllUsersQueryResponse
{
    public string Id { get; set; }
    public string NormalizedUserName { get; set; }
}