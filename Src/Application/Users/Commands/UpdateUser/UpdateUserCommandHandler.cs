// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using ProductsCleanArch.Application.Common.Exceptions;
// using ProductsCleanArch.Application.Common.Interfaces;
// using ProductsCleanArch.Domain.Entities;

// namespace ProductsCleanArch.Application.Users.Commands.UpdateUser
// {
//     public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
//     {
//         private readonly IProductsCleanArchDbContext _context;

//         public UpdateUserCommandHandler(IProductsCleanArchDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
//         {
//             var entity = await _context.Users.FindAsync(request.UserId);
//             if (entity == null)
//             {
//                 throw new NotFoundException(nameof(User), request.UserId);
//             }

//             entity.Age = request.Age;
//             entity.Occupation = request.Occupation;
//             entity.FullName = request.FullName;

//             _context.Users.Update(entity);

//             await _context.SaveChangesAsync(cancellationToken);
//             return Unit.Value;
//         }
//     }
// }