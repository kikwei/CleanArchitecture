using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductsCleanArch.Application.Common.Exceptions;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly IProductsCleanArchDbContext _context;

            public UpdateUserCommandHandler(IProductsCleanArchDbContext context)
            {
                _context = context;
            }

            private static Dictionary<string, string> GetProperties(object obj)
            {
                var props = new Dictionary<string, string>();
                if (obj == null)
                    return props;

                var type = obj.GetType();
                foreach (var prop in type.GetProperties())
                {
                    var val = prop.GetValue(obj, new object[] { });
                    var valStr = val == null ? "" : val.ToString();
                    props.Add(prop.Name, valStr);
                }
                return props;

            }
            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {

                var props = GetProperties(request);
                if (props.Count > 0)
                {
                    Console.WriteLine("-------------------------");
                }

                foreach (var prop in props)
                {
                    Console.Write(prop.Key);
                    Console.Write(": ");
                    Console.WriteLine(prop.Value);
                }

                var entity = await _context.Users.FindAsync(request.UserId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.UserId);
                }

                entity.FullName = request.FullName;
                entity.Age = request.Age;
                entity.Occupation = request.Occupation;

                _context.Users.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}