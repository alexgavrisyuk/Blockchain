using System;
using System.Linq;
using System.Threading.Tasks;
using Blockchain.Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePackageCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}