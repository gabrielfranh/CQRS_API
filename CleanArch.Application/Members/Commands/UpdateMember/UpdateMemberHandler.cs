using AutoMapper;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Members.Commands.UpdateMember
{
    public class UpdateMemberHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        
        public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var commandValidator = new UpdateMemberValidator();
            var requestCommandResult = await commandValidator.ValidateAsync(request, cancellationToken);

            if (!requestCommandResult.IsValid)
                throw new ValidationException(requestCommandResult.Errors);

            var memberToUpdate = _mapper.Map<Member>(request);
            _unitOfWork.MemberRepository.Update(memberToUpdate, cancellationToken);
        }
    }
}
