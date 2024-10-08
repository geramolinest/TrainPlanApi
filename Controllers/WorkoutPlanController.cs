using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Features.WorkoutPlan.Commands;

namespace TrainPlanApi.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkoutPlanController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<AddExcerciseWorkoutPlanCommandResponse>>> AddWorkout(AddWorkoutPlanCommand command)
        {
            var senderResponse = await _sender.Send( command );

            return Ok(senderResponse);
        }
    }
}
