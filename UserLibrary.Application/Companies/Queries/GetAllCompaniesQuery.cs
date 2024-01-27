using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.Application.Companies.Queries
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public record GetAllCompaniesQuery : IRequest<List<CompanyDto>>
    {
        /// <summary>
        /// Filter results by name. Name must contain given string
        /// </summary>
        public string? NameMustContain { get; set; }
    }

    /// <summary>
    /// Get all users query handler
    /// </summary>
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public GetAllCompaniesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Companies
                .Select(x => new CompanyDto()
                {
                    Id = x.Id,
                    Bs = x.Bs,
                    CatchPhrase = x.CatchPhrase,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}