using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Application.Companies;

namespace UserLibrary.Application.Users.Queries
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public record GetAllUsersQuery : IRequest<List<UserDto>>
    {
        /// <summary>
        /// Filter results by name. Name must contain given string
        /// </summary>
        public string? NameMustContain { get; set; }
    }

    /// <summary>
    /// Get all users query handler
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(x => request.NameMustContain == null || x.Name.ToLower().Contains(request.NameMustContain.ToLower()))
                .Select(x => new UserDto()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    Phone = x.Phone,
                    Website = x.Website,
                    Address = new AddressDto()
                    {
                        City = x.City,
                        Street = x.Street,
                        Suite = x.Suite,
                        ZipCode = x.ZipCode
                    },
                    Company = x.Company != null ? new UserCompanyDto()
                    {
                        CatchPhrase = x.Company.CatchPhrase,
                        Bs = x.Company.Bs,
                        Name = x.Company.Name
                    } : null
                }).ToListAsync();
        }
    }
}