using AutoMapper;
using CleanArch.Application.Members.Commands.UpdateMember;
using CleanArch.Domain.Abstractions;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMemberCommand, DeleteMemberResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<DeleteMemberResponse> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var commandValidator = new DeleteMemberValidator();
            var requestCommandResult = await commandValidator.ValidateAsync(request, cancellationToken);

            if (!requestCommandResult.IsValid)
                throw new ValidationException(requestCommandResult.Errors);

            var member = await _unitOfWork.MemberRepository.DeleteMember(request.Id, cancellationToken);
            return _mapper.Map<DeleteMemberResponse>(member);
        }
    }
}
