using AutoMapper;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Members.Commands.CreateMember
{
    public class CreateMemberProfile : Profile
    {
        public CreateMemberProfile()
        {
            CreateMap<CreateMemberCommand, Member>();
            CreateMap<Member, CreateMemberResponse>();
        }
    }
}
