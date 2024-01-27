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

namespace UserLibrary.Application.Companies.Commands
{
    /// <summary>
    /// Create new user command
    /// </summary>
    public record CreateNewCompanyCommand : IRequest
    {
        /// <summary>
        /// No idea
        /// </summary>
        [Required]
        public string Bs { get; set; } = null!;

        /// <summary>
        /// Catch phrase
        /// </summary>
        [Required]
        public string CatchPhrase { get; set; } = null!;

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;
    }

    /// <summary>
    /// <see cref="CreateNewCompanyCommand"/>
    /// </summary>
    public class CreateNewCompanyCommandHandler : IRequestHandler<CreateNewCompanyCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CreateNewCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateNewCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company()
            {
                Name = request.Name,
                CatchPhrase = request.CatchPhrase,
                Bs = request.Bs
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}