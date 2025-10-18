using CQRS_Pattern.AppDBContext;
using CQRS_Pattern.Entity;
using MediatR;

namespace CQRS_Pattern.Features.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly MyDBContext _context;

        public CreateStudentCommandHandler (MyDBContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle (CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student stu = new Student( )
            {
                ID = Guid.NewGuid( ),
                Name = request.Name,
                Age = request.Age
            };
            _context.Students.Add(stu);
            await _context.SaveChangesAsync();
            return stu.ID;
        }
    }
}
