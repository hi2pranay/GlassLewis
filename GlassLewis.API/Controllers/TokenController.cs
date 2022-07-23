using GlassLewis.Core.GlassLewis.Features.Token.Commands;
using GlassLewis.Core.GlassLewis.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlassLewis.API.Controllers
{
    [ServiceFilter(typeof(ExceptionFilter))]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public TokenController(IMediator mediator, ILogger<TokenController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo userData)
        {
            var result = await _mediator.Send(new GetToken(userData)).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
