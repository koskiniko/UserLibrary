using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using UserLibrary.Application.Common.Exceptions;

namespace UserLibrary.Application.Users.Commands
{
    /// <summary>
    /// Update user command
    /// </summary>
    public record UpdateUserCommand : IRequest
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
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
    /// <see cref="UpdateUserCommand"/>
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UpdateUserCommandHandler(IApplicationDbContext context)
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
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
                throw new EntityNotFoundException("user", request.Id);

            if (request.CompanyId != null && await _context.Companies.FindAsync(request.CompanyId) == null)
                throw new EntityNotFoundException("companyId", request.CompanyId.Value);

            user.City = request.City;
            user.Email = request.Email;
            user.Name = request.Name;
            user.Phone = request.Phone;
            user.Street = request.Street;
            user.Suite = request.Suite;
            user.Username = request.Username;
            user.Website = request.Website;
            user.ZipCode = request.ZipCode;
            user.CompanyId = request.CompanyId;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}