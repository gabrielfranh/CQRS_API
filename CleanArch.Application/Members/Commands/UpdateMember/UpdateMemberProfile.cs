using AutoMapper;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Members.Commands.UpdateMember
{
    public class UpdateMemberProfile : Profile
    {
        public UpdateMemberProfile()
        {
            CreateMap<UpdateMemberCommand, Member>();
        }
    }
}