using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils.Identity;
using UseCases.Handlers.Auth.Commands.CreateAccessToken;

namespace Application.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResponse>> Create([FromBody] CreateAccessTokenCommand command) => Ok(await Mediator.Send(command));
    }
}
