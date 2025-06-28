using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOPS.API.Service.Interface;

namespace SmartOPS.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")] // Route userToken
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenService _userTokenService;

        public UserTokenController(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }
    }
}
