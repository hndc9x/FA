using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FPTCertification.Business;
using FPTCertification.Business.Models;
using FPTCertification.Business.Services;
using FPTCertification.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FPTCertification.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IdentityServices _identityServices;
        public UserController(IdentityServices identityServices)
        {
            _identityServices = identityServices;
        }
        /// <summary>
        /// Using for login an account 
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Token object
        /// </returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] RequestLoginModel login)
        {
            //if (ModelState.IsValid)
            //{

            //}
            //await _identityServices.CreateRoles();
            var appUser = await _identityServices.GetUserByUserNameAsync(login.Username);
            if (appUser == null)
            {
                return Unauthorized("Invalid username");
            }
            var result = await _identityServices.SignInAsync(appUser, login);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid password");
            }
            var tokenString = await _identityServices.GenerateJWTTokenAsync(appUser);
            var listRole = _identityServices.GetRole(appUser);
            var response = new TokenResponseLoginModel()
            {
                UserId = appUser.Id,
                Username = appUser.UserName,
                AccessToken = tokenString,
                Role = listRole == null ? "" : listRole.Result.FirstOrDefault()
            };
            return Ok(response);
        }
        //Member AuthenticateMember(Member loginCredentials)
        //{
        //    Member Member = appMembers.SingleOrDefault(x => x.MemberName == loginCredentials.MemberName && x.Password == loginCredentials.Password);
        //    return Member;
        //}


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] AppUser appUser)
        {

            AppUser user = new AppUser()


            {

                UserName = appUser.UserName,

                Fullname = appUser.Fullname,
            };

            var result = await _identityServices.CreateUserAsync(user, "zaQ@1234");
            var id = user.Id;
            if (result.Succeeded)
            {
                return Ok(id);
            }
            return Ok("This is a response from Admin method");
        }


    }
}
