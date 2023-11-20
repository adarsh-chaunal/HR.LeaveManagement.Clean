using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
public class UpdateLeaveTypeCommand : IRequest<Unit> // unit datatype come from MediatR as void is not a valid return type in C#
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
