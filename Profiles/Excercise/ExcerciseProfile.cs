namespace TrainPlanApi.Profiles.Excercise;

using AutoMapper;
using AutoMapper.Features;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using TrainPlanApi.Domain.Excercise;
using TrainPlanApi.Features.Excercise.Commands;
using TrainPlanApi.Features.Excercise.Queries;

public class ExcerciseProfile : Profile
{
    public ExcerciseProfile()
    {
        CreateMap<AddExcerciseCommand, Excercise>();
        
        CreateMap<Excercise, AddExcerciseCommandResponse>();

        CreateMap<Excercise, GetExcerciseByIdQueryResponse>();

        CreateMap<Excercise, GetAllExcercisesQueryResponse>();
        CreateMap<Excercise, UpdateExcerciseCommandResponse>();
    }
}
