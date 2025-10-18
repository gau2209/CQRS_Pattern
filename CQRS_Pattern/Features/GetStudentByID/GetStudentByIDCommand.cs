using CQRS_Pattern.Entity;
using MediatR;

namespace CQRS_Pattern.Features.GetStudentByID
{
    public record GetStudentByIDCommand(Guid ID) : IRequest<Student>;

}
