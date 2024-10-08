using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TrainPlanApi.Features.Users.Queries;

namespace TrainPlanApi.Profiles.Users;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<IdentityUser, GetAllUsersQueryResponse>();
    }
}
