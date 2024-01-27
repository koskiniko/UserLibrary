using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Application.Companies;
using UserLibrary.Application.Companies.Commands;
using UserLibrary.Application.Companies.Queries;

namespace UserLibrary.API.Controllers
{
    /// <summary>
    /// Company related CRU-operations
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        public CompanyController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Create new company
        /// </summary>
        [HttpPost]
        public async Task Create(CreateNewCompanyCommand command)
        {
            await _sender.Send(command);
        }

        /// <summary>
        /// Return all users
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            return await _sender.Send(new GetAllCompaniesQuery());
        }

        /// <summary>
        /// Update company info
        /// </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateCompanyCommand command)
        {
            await _sender.Send(command with { Id = id });
        }
    }
}