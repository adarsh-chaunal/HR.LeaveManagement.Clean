using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid LeaveType", validationResult);

        // Convert to domain entity type
        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request); // LeaveType is also an folder in this project so we are using .Domain to specify the Domain project.

        // add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        // return record id 
        return leaveTypeToCreate.Id; // this id will be updated for the id that was created in database (ef core)
    }
}
