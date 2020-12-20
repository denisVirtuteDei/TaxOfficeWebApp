using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxOfficeWebApp.Models;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TaxOfficeWebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly TaxOfficeContext _context;

        public AccountController(TaxOfficeContext context)
        {
            _context = context;
        }

        [HttpPost, Route("/token")]
        public IActionResult Token([FromBody]JObject data)
        {
            string username = data["username"].ToObject<string>();
            string password = data["password"].ToObject<string>();

            var (identity, prior) = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                priority = prior
            };

            return new JsonResult(response);
        }

        private (ClaimsIdentity, string) GetIdentity(string username, string password)
        {
            //using SHA256 crypt256 = SHA256.Create();
            var shaCrypt = new SHA256Managed();
            var shaStr = shaCrypt.ComputeHash(Encoding.Unicode.GetBytes(password));
            Users user = _context.Users.FirstOrDefault(u => u.UserLogin == username && u.UserPassword == shaStr);
            if (user != null)
            {
                var prior = _context.Priorities.FirstOrDefault(u => u.Id == user.FkPriority);
                if (prior != null)
                {
                    //int personId;

                    //if(prior.PriorityTitle.Equals("admin"))
                    //    personId = _context.Executors.Join
                    //https://www.tutorialsteacher.com/linq/linq-joining-operator-join

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, prior.PriorityTitle)
                    };
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    return (claimsIdentity, prior.PriorityTitle);
                }
            }

            // если пользователя не найдено
            return (null, string.Empty);
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login", "Account");
        //}
    }
}
