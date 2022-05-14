using Authorizer.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Route("authorize")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Authorize()
        {
            if (Request.Headers.ContainsKey("Authorization"))
            {
                Request.Headers.TryGetValue("Authorization", out var accessToken);

                if (!accessToken.ToString().Contains("Bearer"))
                {
                    return BadRequest();
                }

                var user = await _tokenService.VerifyAccess(accessToken.ToString().Replace("Bearer ", ""));

                if (user != null)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
