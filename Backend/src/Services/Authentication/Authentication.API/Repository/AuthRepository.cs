using Authentication.API.Contracts;
using Authentication.API.ExtensionClass;
using Authentication.API.Models;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<ExtendIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthRepository(UserManager<ExtendIdentityUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<ResponseModel> AdminRegister(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return new ResponseModel { Status = "AdminFailed", Message = "User already exists!" };
            ExtendIdentityUser user = new()
            {
                //Email = model.Email,
                //SecurityStamp = Guid.NewGuid().ToString(),
                //UserName = model.UserName
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                Age = model.Age,
                CreatedDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                //status can be error
                return new ResponseModel { Status = "PasswordFailed", Message = "User creation failed! Please check user details and try again." };
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return new ResponseModel { Status = "Success", Message = "User created successfully!" };
        }

        public async Task<object> CheckLoginCred(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var lastLoginDate = user.LastLoginDate;
                user.LastLoginDate = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim("fullname",user.FullName.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("age",user.Age.ToString()),
                    new Claim("id",user.Id.ToString()),
                    new Claim("sex",user.Gender.ToString())

                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                return new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    lastlogindate=lastLoginDate
                };
            }
            return null;
        }

        public async Task<ResponseModel> UserRegister(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            var emailExists=await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null|| emailExists!=null)
                //status can be error
                return new ResponseModel { Status = "UserFailed", Message = "User already exists!" };
            ExtendIdentityUser user = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                Gender=model.Gender,
                Age=model.Age,
                CreatedDate=DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
               
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                //status can be error
                return new ResponseModel { Status = "PasswordFailed", Message = "Please check your password!" };

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return new ResponseModel { Status = "Success", Message = "User created successfully!" };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTAuth:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWTAuth:ValidIssuerURL"],
                audience: _configuration["JWTAuth:ValidAudienceURL"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        public async Task<ResponseModel> DeleteUser(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseModel { Status = "DeleteFailed", Message = "User does not exists!" };
            }
            await _userManager.DeleteAsync(user);
            return new ResponseModel { Status = "Deleted", Message = "User account deleted!" };
        }
        public async Task<ResponseModel> UpdateUser(UpdateUser updateUser, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ResponseModel { Status = "UpdateFailed", Message = "User does not exist!" };
            }

            if (!string.IsNullOrEmpty(updateUser.UserName))
            {
                var userExists = await _userManager.FindByNameAsync(updateUser.UserName);
                if (userExists != null && userExists.Id != userId)
                {
                    return new ResponseModel { Status = "UserFailed", Message = "UserName already exists!" };
                }
                user.UserName = updateUser.UserName;
            }

            if (!string.IsNullOrEmpty(updateUser.Email))
            {
                var emailExists = await _userManager.FindByEmailAsync(updateUser.Email);
                if (emailExists != null && emailExists.Id != userId)
                {
                    return new ResponseModel { Status = "UserFailed", Message = "Email already exists!" };
                }
                user.Email = updateUser.Email;
            }

            if (!string.IsNullOrEmpty(updateUser.FullName))
            {
                user.FullName = updateUser.FullName;
            }

            if (!string.IsNullOrEmpty(updateUser.Gender))
            {
                user.Gender = updateUser.Gender;
            }

            if (updateUser.Age.HasValue)
            {
                user.Age = updateUser.Age.Value;
            }

            if (!string.IsNullOrEmpty(updateUser.Password))
            {
                var passwordHasher = new PasswordHasher<ExtendIdentityUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, updateUser.Password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new ResponseModel { Status = "UpdateFailed", Message = "Failed to update user!" };
            }

            return new ResponseModel { Status = "Success", Message = "User updated successfully!" };
        }

    }
}
