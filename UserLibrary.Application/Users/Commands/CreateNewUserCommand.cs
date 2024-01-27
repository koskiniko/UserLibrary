using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLibrary.Application.Common.Exceptions;
using UserLibrary.Application.Users.Queries;
using UserLibrary.Domain.Entities;

namespace UserLibrary.Application.Users.Commands
{
    /// <summary>
    /// Create new user command
    /// </summary>
    public record CreateNewUserCommand : IRequest
    {
        /// <summary>
        /// City
        /// </summary>
        [Required]
        public string City { get; set; } = null!;

        /// <summary>
        /// Company id if any
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// Email address of the user
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;
        /// <summary>
        /// Full name of the user
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number of the user
        /// </summary>
        [Required]
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Street
        /// </summary>
        [Required]
        public string Street { get; set; } = null!;

        /// <summary>
        /// Suite
        /// </summary>
        [Required]
        public string Suite { get; set; } = null!;

        /// <summary>
        /// Username of the user
        /// </summary>
        [Required]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Website of the user
        /// </summary>
        [Required]
        public string Website { get; set; } = null!;

        /// <summary>
        /// Zip code
        /// </summary>
        [Required]
        public string ZipCode { get; set; } = null!;
    }

    /// <summary>
    /// <see cref="CreateNewUserCommand"/>
    /// </summary>
    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CreateNewUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            if (request.CompanyId != null && await _context.Companies.FindAsync(request.CompanyId) == null)
                throw new EntityNotFoundException("companyId", request.CompanyId.Value);

            var user = new User()
            {
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                Street = request.Street,
                City = request.City,
                Suite = request.Suite,
                ZipCode = request.ZipCode,
                Username = request.Username,
                Website = request.Website,
                CompanyId = request.CompanyId
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}