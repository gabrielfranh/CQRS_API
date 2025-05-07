using AutoMapper;
using CleanArch.Application.Validators;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.Members.Commands.CreateMember
{
    public class CreateMemberHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMemberCommand, CreateMemberResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateMemberResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var commandValidator = new CreateMemberValidator();
            var requestCommandResult = await commandValidator.ValidateAsync(request, cancellationToken);

            if (!requestCommandResult.IsValid)
                throw new ValidationException(requestCommandResult.Errors);

            var member = _mapper.Map<Member>(request);
            
            var newMember = await _unitOfWork.MemberRepository.Add(member, cancellationToken);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CreateMemberResponse>(newMember);
        }
    }
}