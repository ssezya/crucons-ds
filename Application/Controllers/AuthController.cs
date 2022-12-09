using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils.Identity;
using UseCases.Handlers.Auth.Commands.CreateToken;

namespace Application.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("access-token")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResponse>> Create([FromBody] CreateTokenCommand command) => Ok(await Mediator.Send(command));
    }
}
