using Authentication.API.Contracts;
using Authentication.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuth _authRepo;
        public AuthenticationController(IAuth authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authRepo.CheckLoginCred(model);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized("User does not exist! please register.");
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _authRepo.UserRegister(model);
            //if (userExists.Status == "Failed")
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, userExists);
            //}
            return Ok(userExists);
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _authRepo.AdminRegister(model);
            //if (userExists.Status == "Failed")
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, userExists);
            //}
            return Ok(userExists);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result=await _authRepo.DeleteUser(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("update-user/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUser updateUser)
        {
            var result = await _authRepo.UpdateUser(updateUser,userId);
            return Ok(result);
        }
    }
}
