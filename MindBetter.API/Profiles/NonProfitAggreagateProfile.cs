using AutoMapper;
using MindBetter.API.Dtos;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NonProfitAggregate;

namespace MindBetter.API.Profiles
{
    public class NonProfitAggreagateProfile : Profile
    {
        public NonProfitAggreagateProfile()
        {
            CreateMap<NonProfit, NonProfitDto>();
            CreateMap<Service, ServiceDto>();
            CreateMap<Member, MemberDto>().IncludeBase<User, UserDto>();
            CreateMap<User, UserDto>();
        }

    }
}
