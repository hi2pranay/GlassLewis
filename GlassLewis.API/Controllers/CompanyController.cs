using GlassLewis.Core.GlassLewis.Features.Company.Commands;
using GlassLewis.Core.GlassLewis.Features.Company.Queries;
using GlassLewis.Core.GlassLewis.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GlassLewis.API.Controllers
{
    [Authorize]
    //[ServiceFilter(typeof(ExceptionFilter))]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/glasslewis/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowAll")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("GetAllCompanies")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _mediator.Send(new GlassLewisGetAllCompanies()).ConfigureAwait(false);
            return Ok(companies);
        }

        [Route("GetCompanyById/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyById(int Id)
        {
            var company = await _mediator.Send(new GlassLewisGetCompanyById(Id)).ConfigureAwait(false);
            return Ok(company);
        }

        [Route("GetCompanyByISIN/{ISIN}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyByISIN(string ISIN)
        {
            var company = await _mediator.Send(new GlassLewisGetCompanyByISIN(ISIN)).ConfigureAwait(false);
            return Ok(company);
        }

        [Route("CreateCompany")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            var result = await _mediator.Send(new CreateCompany(company)).ConfigureAwait(false);
            return Ok(result);
        }

        [Route("UpdateCompany")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Company company)
        {
            var result = await _mediator.Send(new UpdateCompany(company)).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
