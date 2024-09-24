using Microsoft.AspNetCore.Identity;

namespace Authentication.API.ExtensionClass
{
    public class ExtendIdentityUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
