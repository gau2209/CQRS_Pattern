using MediatR;

namespace CQRS_Pattern.Features.CreateStudent
{
    public record CreateStudentCommand(string Name,int Age) : IRequest<Guid>;

}
