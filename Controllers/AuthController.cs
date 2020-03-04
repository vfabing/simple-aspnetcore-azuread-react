using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace simple_aspnetcore_azuread_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(CancellationToken cancellationToken = default)
        {
            if (User.Identity.IsAuthenticated) // = Is User authenticated by Azure AD
            {
                try
                {
                    // Check if user access is legitimate on this website, and throw UnauthorizedAccessException if not
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized(new { Message = "You are not authorized to access to this platform." });
                }
            }
            else
            {
                // Trigger Azure AD authentication (using redirection)
                return Challenge(AzureADDefaults.OpenIdScheme);
            }
            // Redirect to home page is successfully authenticated
            return Redirect("/");
        }
    }
}
