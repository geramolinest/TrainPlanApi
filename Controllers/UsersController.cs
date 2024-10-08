using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Features.Users.Queries;

namespace TrainPlanApi.Controllers;
[ApiController]
[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<List<GetAllUsersQueryResponse>>>> GetAllUsers()
    {
        var senderResponse = await _sender.Send( new GetAllUsersQuery() );

        if(senderResponse.StatusCode == 500) return StatusCode(500, senderResponse);

        return Ok( senderResponse );
    }
}
