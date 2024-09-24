using Authentication.API.Models;
using Microsoft.Win32;

namespace Authentication.API.Contracts
{
    public interface IAuth
    {
        public Task<object> CheckLoginCred(LoginModel model);

        public Task<ResponseModel> UserRegister(RegisterModel model);

        public Task<ResponseModel> AdminRegister(RegisterModel model);
        public Task<ResponseModel> DeleteUser(string userId);
        public Task<ResponseModel> UpdateUser(UpdateUser updateUser, string userId);
    }
}
