using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.Models;
using MyProject.Utils;

namespace MyProject.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("auth-me/{username}")]
        public ActionResult AuthUser(string username)
        {   
            Claim roleClaim;
            if (username.Contains("admin")){
                roleClaim = new Claim(ClaimTypes.Role, Roles.Admin);
            } else {
                roleClaim = new Claim(ClaimTypes.Role, Roles.User);
            }
            var claims = new List<Claim> {new Claim(ClaimTypes.Name, username), roleClaim};
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Content( token );
        }

        [HttpGet]
        [Route("auth-me/")]
        public ActionResult AuthUser()
        {
           return RedirectPermanent("/auth-me/test-username");
        }

    }
}