using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Secure.Models;
using sell_movie.Secure.Service;

namespace sell_movie.Secure.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenServices services_;
        public TokenController(ITokenServices services_)
        {
            this.services_ = services_;
        }
        [HttpPost("create-token")]
        public async Task<IActionResult> Create(LoginModels models)
        {
            var result = await services_.Validate(models);
            if (result == null)
            {
                return BadRequest("đã có lỗi!");
            }
            return Ok(result);
        }
        [HttpPost("renew")]
        public async Task<IActionResult> RenewToken(TokenModels models)
        {
            var result = await services_.RenewToken(models);
            if (result == null)
            {
                return BadRequest("đã có lỗi renew!");
            }
            return Ok(result);
        }
    }
}
