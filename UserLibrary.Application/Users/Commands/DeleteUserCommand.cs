using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Application.Common.Exceptions;
using UserLibrary.Domain.Entities;

namespace UserLibrary.Application.Users.Commands
{
    /// <summary>
    /// Delete user from the system
    /// </summary>
    public record DeleteUserCommand : IRequest
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// <see cref="DeleteUserCommand"/>
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);
            if (user == null)
                throw new EntityNotFoundException("id", request.Id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}