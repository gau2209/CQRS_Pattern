using CQRS_Pattern.AppDBContext;
using CQRS_Pattern.Entity;
using MediatR;

namespace CQRS_Pattern.Features.GetStudentByID
{
    public class GetStudentByIDCommandHandler : IRequestHandler<GetStudentByIDCommand, Student>
    {
        private readonly MyDBContext _context;

        public GetStudentByIDCommandHandler (MyDBContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle (GetStudentByIDCommand request, CancellationToken cancellationToken)
        {
            return await _context.Students.FindAsync(request.ID);
        }
    }
}
