namespace TrainPlanApi.Features.Excercise.Commands;

using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services.Interfaces;

public class UpdateExcerciseCommand : IRequest<BaseResponse<UpdateExcerciseCommandResponse>>
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}

public class UpdateExcerciseParams
{
    [Required]
    public string Name { get; set; }
}

public class UpdateExcerciseCommandHandler : IRequestHandler<UpdateExcerciseCommand, BaseResponse<UpdateExcerciseCommandResponse>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<UpdateExcerciseCommandHandler> _logger;
    private readonly IResponseService<UpdateExcerciseCommandResponse> _response;
    private readonly IMapper _mapper;

    public UpdateExcerciseCommandHandler(ApplicationDBContext dbContext, ILogger<UpdateExcerciseCommandHandler> logger, IResponseService<UpdateExcerciseCommandResponse> response, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _response = response;
        _mapper = mapper;
    }
    public async Task<BaseResponse<UpdateExcerciseCommandResponse>> Handle(UpdateExcerciseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var excercise = await _dbContext.Excercises.FirstOrDefaultAsync( e => e.Id == request.Id );
            
            if( excercise is null ) return _response.BadRequestResponse("Excercise does not exists.");
            
            excercise.Name = request.Name;

            await _dbContext.SaveChangesAsync();

            var excerciseResponse = _mapper.Map<UpdateExcerciseCommandResponse>( excercise );

            return _response.OkResponse( "Excercise has beeen modified.", excerciseResponse );
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return _response.InternalServerErrorResponse();
        }
    }
}

public class UpdateExcerciseCommandResponse 
{
    public int Id { get; set; }
    public string Name { get; set; }
}
