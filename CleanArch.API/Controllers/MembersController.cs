using CleanArch.Application.Members.Commands.CreateMember;
using CleanArch.Application.Members.Commands.DeleteMember;
using CleanArch.Application.Members.Commands.UpdateMember;
using CleanArch.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController(IMediator mediator, IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var members = await _unitOfWork.MemberRepository.Get(cancellationToken);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.MemberRepository.GetById(id, cancellationToken);

            return member is not null ? Ok(member) : NotFound("Member not found");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMemberCommand command)
        {
            var memberResult = await _mediator.Send(command);
            return Ok(memberResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMemberCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMemberCommand
            {
                Id = id
            };

            var deleteResponse = await _mediator.Send(command);

            if (deleteResponse is null)
                return NotFound("Member not found");

            return Ok(deleteResponse);
        }
    }
}
