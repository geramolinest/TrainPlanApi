using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Features.Excercise.Commands;
using TrainPlanApi.Features.Excercise.Queries;

namespace TrainPlanApi.Controllers;

[ApiController]
[Route("api/excercises")]
[Authorize]
public class ExcercisesController : ControllerBase
{
    private readonly ISender _sender;
    public ExcercisesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BaseResponse<GetExcerciseByIdQueryResponse>>> GetExcerciseByIdQuery(int id)
    {
        var senderResponse = await _sender.Send( new GetExcerciseByIdQuery() { Id = id });

        if(senderResponse.StatusCode == 500) return StatusCode( 500, senderResponse );

        if(senderResponse.StatusCode > 299 ) return NotFound( senderResponse );

        return Ok( senderResponse );
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<List<GetAllExcercisesQueryResponse>>>> GetAllExcercises()
    {
        var senderResponse = await _sender.Send( new GetAllExcercisesQuery() );

        if(senderResponse.StatusCode == 500) return StatusCode( 500, senderResponse );

        return Ok( senderResponse );
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<AddExcerciseCommandResponse>>> AddExcercise(AddExcerciseCommand request)
    {
        var senderResponse = await _sender.Send( request );
        
        if(senderResponse.StatusCode == 500) return StatusCode( 500, senderResponse );

        if(senderResponse.StatusCode > 299 ) return BadRequest( senderResponse );

        return CreatedAtAction( nameof(GetExcerciseByIdQuery), new { Id = senderResponse.Data.Id }, senderResponse );
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<BaseResponse<UpdateExcerciseCommandResponse>>> UpdateExcercise(int id, [FromBody] UpdateExcerciseParams excerciseParams)
    {
        var senderResponse = await _sender.Send( new UpdateExcerciseCommand() { Id = id, Name = excerciseParams.Name} );
        
        if(senderResponse.StatusCode == 500) return StatusCode( 500, senderResponse );

        if(senderResponse.StatusCode > 299 ) return BadRequest( senderResponse );

        return Ok( senderResponse );
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BaseResponse<DisableExcerciseCommandResponse>>> DisableExcercise(int id)
    {
        var senderResponse = await _sender.Send( new DisableExcerciseCommand() { Id = id });

        if(senderResponse.StatusCode == 500) return StatusCode( 500, senderResponse );

        if(senderResponse.StatusCode > 299 ) return BadRequest( senderResponse );

        return Ok( senderResponse );
    }
}
