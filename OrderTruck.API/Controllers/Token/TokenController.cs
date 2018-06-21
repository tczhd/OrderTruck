using Microsoft.AspNetCore.Mvc;
using Fiver.Security.Bearer.Models.Token;
using Fiver.Security.Bearer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OrderTruck.Model;
using OrderTruck.API.Models.AccountViewModels;
using OrderTruck.API.Services;

namespace Fiver.Security.Bearer.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public TokenController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<TokenController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        //[HttpPost]
        //public IActionResult Create([FromBody]LoginInputModel inputModel)
        //{
        //    if (inputModel.Username != "james" && inputModel.Password != "bond")
        //        return Unauthorized();

        //    var token = new JwtTokenBuilder()
        //                        .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
        //                        .AddSubject("james bond")
        //                        .AddIssuer("Fiver.Security.Bearer")
        //                        .AddAudience("Fiver.Security.Bearer")
        //                        .AddClaim("MembershipId", "111")
        //                        .AddExpiry(1)
        //                        .Build();

        //    //return Ok(token);
        //    return Ok(token.Value);
        //}
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = _signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, true, lockoutOnFailure: false).Result;
                if (!result.Succeeded)
                {
                    return Unauthorized();
                }

                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                    .AddSubject("james bond")
                                    .AddIssuer("Fiver.Security.Bearer")
                                    .AddAudience("Fiver.Security.Bearer")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(1)
                                    .Build();

                //return Ok(token);
                return Ok(token.Value);
            }

            return NotFound();
        }
    }
}
