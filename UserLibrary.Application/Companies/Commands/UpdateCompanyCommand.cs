using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLibrary.Application.Common.Exceptions;

namespace UserLibrary.Application.Companies.Commands
{
    /// <summary>
    /// Update user command
    /// </summary>
    public record UpdateCompanyCommand : IRequest
    {
        /// <summary>
        /// Id of the company
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// No idea
        /// </summary>
        public string Bs { get; set; } = null!;

        /// <summary>
        /// Catch phrase
        /// </summary>
        public string CatchPhrase { get; set; } = null!;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;
    }

    /// <summary>
    /// <see cref="UpdateCompanyCommand"/>
    /// </summary>
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UpdateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync(request.Id);

            if (company == null)
                throw new EntityNotFoundException("id", request.Id);

            company.CatchPhrase = request.CatchPhrase;
            company.Name = request.Name;
            company.Bs = request.Bs;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}